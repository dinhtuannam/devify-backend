using Devify.Entity;
using System.ComponentModel.DataAnnotations;

namespace Devify.Models
{
    public class CreateLevelModel
    {
        [Required(ErrorMessage = "Trường name là bắt buộc.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Tên chỉ được chứa chữ cái, số và khoảng trắng.")]
        [MaxLength(20, ErrorMessage = "Tên không được dài hơn 20 kí tự.")]
        public string LevelName { get; set; }
        public string LevelDescription { get; set; }
    }

    public class UpdateLevelModel
    {
        [Required(ErrorMessage = "Trường id là bắt buộc.")]
        public string CourseLevelId { get; set; }
        [Required(ErrorMessage = "Trường name là bắt buộc.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Tên chỉ được chứa chữ cái, số và khoảng trắng.")]
        [MaxLength(20, ErrorMessage = "Tên không được dài hơn 20 kí tự.")]
        public string LevelName { get; set; }
        public string LevelDescription { get; set; }
        //[Required(ErrorMessage = "Trường status là bắt buộc.")]

    }
}
