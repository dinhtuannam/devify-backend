using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    public class TrackEntity
    {
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }
    }
}
