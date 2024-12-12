namespace Horizons.Models
{
    public class DestinationIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Terrain { get; set; } = string.Empty;

        public int FavoritesCount { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsPublisher { get; set; }

        public bool IsFavorite { get; set; }
    }
}
