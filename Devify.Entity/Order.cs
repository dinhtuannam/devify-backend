using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Devify.Entity.Commons;

namespace Devify.Entity
{
    [Table("Orders")]
    public class Order : TrackEntity
    {
        [Key]
        public Guid OrderId { get; set; }
        [ForeignKey("User")]
        public string UserBuyId { get; set; }
        public string? Description { get; set; }
        public double Total { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<DetailOrder> DetailOrders { get; set; } = new List<DetailOrder>();
    }
}
