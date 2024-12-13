using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Horizons.Data.DataModels
{
    [PrimaryKey(nameof(UserId), nameof(DestinationId))]
    [Comment("The relational table between users and marked destinations as favorite")]
    public class UserDestination
    {
        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [Comment("Destination identifier")]
        public int DestinationId { get; set; }

        [ForeignKey(nameof(DestinationId))]
        public Destination Destination { get; set; } = null!;
    }
}
