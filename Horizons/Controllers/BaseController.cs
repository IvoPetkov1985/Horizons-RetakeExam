using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Horizons.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            string userId;

            if (User == null)
            {
                userId = string.Empty;
            }
            else
            {
                userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }
    }
}
