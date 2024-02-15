using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class CartItem
    {
        public double amount { get; set; } = 0;
        public double discount_price { get; set; } = 0;
        public double total { get; set; } = 0;
        public UserShortInfo user { get; set; } = new UserShortInfo();
        public DiscountItem discount { get; set; } = new DiscountItem();
        public List<ProductInCart> items { get; set; } = new List<ProductInCart>();
    }

    public class ProductInCart
    {
        public string code { get; set; } = "";
        public string title { get; set; } = "";
        public double price { get; set; } = 0;
        public string image { get; set; } = "";
        public string createTime { get; set; } = "";
        public string updateTime { get; set; } = "";
    }
}
