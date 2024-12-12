using Horizons.Contracts;
using Horizons.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static Horizons.Common.DataConstants;

namespace Horizons.Controllers
{
    public class DestinationController(IDestinationService _service) : BaseController
    {
        private readonly IDestinationService service = _service;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = GetUserId();

            IEnumerable<DestinationIndexViewModel> model = await service.GetAllDestinationsAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            IEnumerable<TerrainViewModel> terrains = await service.GetAllTerrainsAsync();

            DestinationFormModel model = new()
            {
                Terrains = terrains
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DestinationFormModel model)
        {
            if (DateTime.TryParseExact(model.PublishedOn, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date) == false)
            {
                ModelState.AddModelError(nameof(model.PublishedOn), DateInvalidErrorMessage);
            }

            IEnumerable<TerrainViewModel> terrains = await service.GetAllTerrainsAsync();

            if (terrains.Any(t => t.Id == model.TerrainId) == false)
            {
                ModelState.AddModelError(nameof(model.TerrainId), TerrainInvalidErrorMessage);
            }

            if (ModelState.IsValid == false)
            {
                model.Terrains = terrains;

                return View(model);
            }

            string userId = GetUserId();

            await service.AddNewDestinationAsync(model, userId);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await service.IsDestinationExistingAsync(id) == false)
            {
                return NotFound();
            }

            string userId = GetUserId();

            DestinationDetailsViewModel model = await service.CreateDetailsModelAsync(userId, id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await service.IsDestinationExistingAsync(id) == false)
            {
                return NotFound();
            }

            string userId = GetUserId();

            if (await service.IsUserAuthorizedAsync(userId, id) == false)
            {
                return Unauthorized();
            }

            DestinationEditFormModel model = await service.CreateEditModelAsync(id);

            IEnumerable<TerrainViewModel> terrains = await service.GetAllTerrainsAsync();

            model.Terrains = terrains;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DestinationEditFormModel model, int id)
        {
            if (await service.IsDestinationExistingAsync(id) == false)
            {
                return NotFound();
            }

            string userId = GetUserId();

            if (await service.IsUserAuthorizedAsync(userId, id) == false)
            {
                return Unauthorized();
            }

            if (DateTime.TryParseExact(model.PublishedOn, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date) == false)
            {
                ModelState.AddModelError(nameof(model.PublishedOn), DateInvalidErrorMessage);
            }

            IEnumerable<TerrainViewModel> terrains = await service.GetAllTerrainsAsync();

            if (terrains.Any(t => t.Id == model.TerrainId) == false)
            {
                ModelState.AddModelError(nameof(model.TerrainId), TerrainInvalidErrorMessage);
            }

            if (ModelState.IsValid == false)
            {
                model.Terrains = terrains;

                return View(model);
            }

            await service.EditDestinationAsync(model, id);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            string userId = GetUserId();

            IEnumerable<DestinationFavViewModel> model = await service.GetAllFavDestinationsAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int id)
        {
            if (await service.IsDestinationExistingAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await service.AddToFavoritesAsync(userId, id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            if (await service.IsDestinationExistingAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            await service.RemoveFromFavoritesAsync(userId, id);

            return RedirectToAction(nameof(Favorites));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await service.IsDestinationExistingAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (await service.IsUserAuthorizedAsync(userId, id) == false)
            {
                return Unauthorized();
            }

            DestinationDeleteViewModel model = await service.CreateDeleteModelAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DestinationDeleteViewModel model, int id)
        {
            if (await service.IsDestinationExistingAsync(id) == false)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (await service.IsUserAuthorizedAsync(userId, id) == false)
            {
                return Unauthorized();
            }

            await service.DeleteSoftDestinationAsync(model.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
