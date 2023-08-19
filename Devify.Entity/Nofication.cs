using Devify.Entity.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("Nofications")]
    public class Nofication : TrackEntity
    {
        [Key]
        public int NoficationId { get; set; }   
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
