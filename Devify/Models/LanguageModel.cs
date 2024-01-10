using System.ComponentModel.DataAnnotations;

namespace Devify.Models
{
    public class CreateLanguageModel
    {
        [Required(ErrorMessage = "Trường name là bắt buộc.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Tên chỉ được chứa chữ cái, số và khoảng trắng.")]
        [MaxLength(20, ErrorMessage = "Tên không được dài hơn 20 kí tự.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Trường status là bắt buộc.")]
        public string Status { get; set; }
    }

    public class UpdateLanguageModel
    {
        [Required]
        public string LanguageId { get; set; }
        [Required(ErrorMessage = "Trường name là bắt buộc.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Tên chỉ được chứa chữ cái, số và khoảng trắng.")]
        [MaxLength(20, ErrorMessage = "Tên không được dài hơn 20 kí tự.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Trường status là bắt buộc.")]
        public string Status { get; set; }
        
    }
}
