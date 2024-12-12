using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Horizons.Common.DataConstants;

namespace Horizons.Data.Models
{
    [Comment("Terrain of the destination")]
    public class Terrain
    {
        [Key]
        [Comment("Terrain identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TerrainNameMaxLength)]
        [Comment("Terrain name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Destination> Destinations { get; set; } = [];
    }
}
