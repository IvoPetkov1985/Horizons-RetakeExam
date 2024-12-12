using Horizons.Contracts;
using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Models;
using Microsoft.EntityFrameworkCore;
using static Horizons.Common.DataConstants;

namespace Horizons.Services
{
    public class DestinationService(ApplicationDbContext _context) : IDestinationService
    {
        private readonly ApplicationDbContext context = _context;

        public async Task AddNewDestinationAsync(DestinationFormModel model, string userId)
        {
            Destination destination = new()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                TerrainId = model.TerrainId,
                PublishedOn = DateTime.Parse(model.PublishedOn),
                PublisherId = userId
            };

            await context.Destinations.AddAsync(destination);

            await context.SaveChangesAsync();
        }

        public async Task AddToFavoritesAsync(string userId, int id)
        {
            UserDestination entry = new()
            {
                UserId = userId,
                DestinationId = id
            };

            if (await context.UsersDestinations.ContainsAsync(entry) == false)
            {
                await context.UsersDestinations.AddAsync(entry);

                await context.SaveChangesAsync();
            }
        }

        public async Task<DestinationDeleteViewModel> CreateDeleteModelAsync(int id)
        {
            DestinationDeleteViewModel deleteModel = await context.Destinations
                .AsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new DestinationDeleteViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Publisher = d.Publisher.UserName,
                    PublisherId = d.PublisherId
                })
                .SingleAsync();

            return deleteModel;
        }

        public async Task<DestinationDetailsViewModel> CreateDetailsModelAsync(string userId, int id)
        {
            DestinationDetailsViewModel details = await context.Destinations
                .AsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new DestinationDetailsViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    PublishedOn = d.PublishedOn.ToString(DateFormat),
                    Publisher = d.Publisher.UserName,
                    Terrain = d.Terrain.Name,
                    IsFavorite = d.UsersDestinations.Any(ud => ud.UserId == userId),
                    IsPublisher = d.PublisherId == userId
                })
                .SingleAsync();

            return details;
        }

        public async Task<DestinationEditFormModel> CreateEditModelAsync(int id)
        {
            DestinationEditFormModel editModel = await context.Destinations
                .AsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new DestinationEditFormModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    PublishedOn = d.PublishedOn.ToString(DateFormat),
                    PublisherId = d.PublisherId,
                    TerrainId = d.TerrainId
                })
                .SingleAsync();

            return editModel;
        }

        public async Task DeleteSoftDestinationAsync(int id)
        {
            Destination destination = await context.Destinations
                .SingleAsync(d => d.Id == id);

            destination.IsDeleted = true;

            await context.SaveChangesAsync();
        }

        public async Task EditDestinationAsync(DestinationEditFormModel model, int id)
        {
            Destination destination = await context.Destinations
                .SingleAsync(d => d.Id == id);

            destination.Name = model.Name;
            destination.Description = model.Description;
            destination.ImageUrl = model.ImageUrl;
            destination.TerrainId = model.TerrainId;
            destination.PublishedOn = DateTime.Parse(model.PublishedOn);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DestinationIndexViewModel>> GetAllDestinationsAsync(string userId)
        {
            IEnumerable<DestinationIndexViewModel> allDestinations = await context.Destinations
                .AsNoTracking()
                .Where(d => d.IsDeleted == false)
                .Select(d => new DestinationIndexViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    Terrain = d.Terrain.Name,
                    IsPublisher = d.PublisherId == userId,
                    IsFavorite = d.UsersDestinations.Any(ud => ud.UserId == userId),
                    FavoritesCount = d.UsersDestinations.Count(),
                })
                .ToListAsync();

            return allDestinations;
        }

        public async Task<IEnumerable<DestinationFavViewModel>> GetAllFavDestinationsAsync(string userId)
        {
            IEnumerable<DestinationFavViewModel> favorites = await context.UsersDestinations
                .AsNoTracking()
                .Where(ud => ud.UserId == userId)
                .Select(ud => new DestinationFavViewModel()
                {
                    Id = ud.Destination.Id,
                    Name = ud.Destination.Name,
                    ImageUrl = ud.Destination.ImageUrl,
                    Terrain = ud.Destination.Terrain.Name
                })
                .ToListAsync();

            return favorites;
        }

        public async Task<IEnumerable<TerrainViewModel>> GetAllTerrainsAsync()
        {
            IEnumerable<TerrainViewModel> allTerrains = await context.Terrains
                .AsNoTracking()
                .Select(t => new TerrainViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();

            return allTerrains;
        }

        public async Task<bool> IsDestinationExistingAsync(int id)
        {
            Destination? destination = await context.Destinations
                .AsNoTracking()
                .Where(d => d.Id == id && d.IsDeleted == false)
                .SingleAsync();

            return destination != null;
        }

        public async Task<bool> IsUserAuthorizedAsync(string userId, int id)
        {
            Destination destination = await context.Destinations
                .AsNoTracking()
                .SingleAsync(d => d.Id == id);

            return destination.PublisherId == userId;
        }

        public async Task RemoveFromFavoritesAsync(string userId, int id)
        {
            UserDestination entry = new()
            {
                UserId = userId,
                DestinationId = id
            };

            if (await context.UsersDestinations.ContainsAsync(entry))
            {
                context.UsersDestinations.Remove(entry);

                await context.SaveChangesAsync();
            }
        }
    }
}
