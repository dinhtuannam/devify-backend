using Devify.Entity.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("Notifications")]
    public class Notification : TrackEntity
    {
        [Key]
        public int NotificationId { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

    }
}
