using Devify.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class DiscountItem
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public double value { get; set; } = 0;
        public DiscountEnum type { get; set; } = DiscountEnum.Price;
        public int quantity { get; set; } = 0;
        public double minimum { get; set; } = 0;
        public string expiredTime { get; set; } = "";
    }
}
