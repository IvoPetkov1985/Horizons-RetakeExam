namespace Horizons.Models
{
    public class DestinationDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string Terrain { get; set; } = string.Empty;

        public DateTime PublishedOn { get; set; }

        public string Publisher { get; set; } = string.Empty;

        public bool IsPublisher { get; set; }

        public bool IsFavorite { get; set; }
    }
}
