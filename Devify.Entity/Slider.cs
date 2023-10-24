using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("Sliders")]
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        public string? Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public string? Button { get; set; } = "";
        public string? Link { get; set; } = "";
        public string? Image { get; set; } = "";
    }
}
