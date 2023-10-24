using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("DetailOrders")]
    public class DetailOrder
    {
        public Guid OrderId { get; set; }
        public Guid CourseId { get; set; }
        public double CoursePrice { get; set; } = 0;
        public Order Order { get; set; }
        public Course Course { get; set; }

    }
}
