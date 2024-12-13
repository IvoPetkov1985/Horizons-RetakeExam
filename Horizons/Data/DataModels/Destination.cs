using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Horizons.Data.Common.DataConstants;

namespace Horizons.Data.DataModels
{
    [Comment("Bulgarian destination")]
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
        [Comment("Detailed information about the destination")]
        public string Description { get; set; } = string.Empty;

        [MaxLength(ImageUrlMaxLength)]
        [Comment("Link to a photo from the place")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("User identifier")]
        public string PublisherId { get; set; } = string.Empty;

        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        [Comment("When the ad was published on the platform")]
        public DateTime PublishedOn { get; set; }

        [Required]
        [Comment("Terrain identifier")]
        public int TerrainId { get; set; }

        [ForeignKey(nameof(TerrainId))]
        public Terrain Terrain { get; set; } = null!;

        [Required]
        [Comment("Is the ad outdated, set as inactive")]
        public bool IsDeleted { get; set; }

        public IEnumerable<UserDestination> UsersDestinations { get; set; } = [];
    }
}
