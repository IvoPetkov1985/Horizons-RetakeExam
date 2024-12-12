using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Horizons.Common.DataConstants;

namespace Horizons.Data.Models
{
    [Comment("A destination in Bulgaria")]
    public class Destination
    {
        [Key]
        [Comment("Destination identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DestinationNameMaxLength)]
        [Comment("Destination name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Details about the destination")]
        public string Description { get; set; } = string.Empty;

        [Comment("Link to a photo from the site")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("User identifier")]
        public string PublisherId { get; set; } = string.Empty;

        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        [Comment("Date, when the ad was published")]
        public DateTime PublishedOn { get; set; }

        [Required]
        [Comment("Terrain identifier")]
        public int TerrainId { get; set; }

        [ForeignKey(nameof(TerrainId))]
        public Terrain Terrain { get; set; } = null!;

        [Required]
        [Comment("Is the ad outdated")]
        public bool IsDeleted { get; set; } = false;

        public IEnumerable<UserDestination> UsersDestinations { get; set; } = [];
    }
}
