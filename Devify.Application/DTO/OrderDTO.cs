using Devify.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class OrderCheckoutDTO
    {
        public Guid OrderId { get; set; }
        public string UserBuyId { get; set; }
        public string? Description { get; set; }
        public double Total { get; set; }
        public ICollection<OrderCheckoutItemDTO> orderItems { get; set; } = new List<OrderCheckoutItemDTO>();
    }

    public class OrderCheckoutItemDTO
    {
        public Guid CourseId { get; set; }
        public double CoursePrice { get; set; }
    }
}
