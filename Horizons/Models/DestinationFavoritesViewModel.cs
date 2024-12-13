namespace Horizons.Models
{
    public class DestinationFavoritesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string Terrain { get; set; } = string.Empty;
    }
}
