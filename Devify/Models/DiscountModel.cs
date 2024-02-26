using Devify.Entity.Enums;

namespace Devify.Models
{
    public class CreateDiscount
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

    public class UpdateDiscount
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
