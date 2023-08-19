using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
        public string? Image { get; set; }
        public Creator? Creator { get; set; }
        public ICollection<Order>? Orders { get; } = new List<Order>();
        public ICollection<Nofication>? Nofications { get; } = new List<Nofication>();
    }
}
