using Horizons.Models;

namespace Horizons.Contracts
{
    public interface IDestinationService
    {
        Task AddDestinationAsync(DestinationAddFormModel model, string userId);

        Task AddToFavoritesAsync(string userId, int id);

        Task<DestinationDeleteViewModel> CreateDeleteModelAsync(int id);

        Task<DestinationDetailsViewModel> CreateDetailsModelAsync(string userId, int id);

        Task<DestinationEditFormModel> CreateEditModelAsync(int id);

        Task EditDestinationAsync(DestinationEditFormModel model, int id);

        Task<IEnumerable<DestinationIndexViewModel>> GetAllDestinationsAsync(string userId);

        Task<IEnumerable<TerrainViewModel>> GetAllTerrainsAsync();

        Task<IEnumerable<DestinationFavoritesViewModel>> GetUserFavoritesAsync(string userId);

        Task<bool> IsDestinationAvailableAsync(int id);

        Task<bool> IsUserAuthorizedAsync(string userId, int id);

        Task RemoveFromFavoritesAsync(string userId, int id);

        Task SoftDeleteDestinationAsync(int id1, int id2);
    }
}
