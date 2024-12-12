using System.ComponentModel.DataAnnotations;
using static Horizons.Common.DataConstants;

namespace Horizons.Models
{
    public class DestinationFormModel
    {
        [Required]
        [StringLength(DestinationNameMaxLength, MinimumLength = DestinationNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = PublishedOnRequiredErrorMsg)]
        [RegularExpression(DateRegex, ErrorMessage = DateFormatErrorMessage)]
        public string PublishedOn { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int TerrainId { get; set; }

        public IEnumerable<TerrainViewModel> Terrains { get; set; } = [];
    }
}
