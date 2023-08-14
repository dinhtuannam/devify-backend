﻿using Devify.Entity.Commons;
using Devify.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Devify.Entity
{
    [Table("Categories")]
    public class Category : TrackEntity
    {
        [Key]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Trường name là bắt buộc.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Tên chỉ được chứa chữ cái, số và khoảng trắng.")]
        [MaxLength(20, ErrorMessage = "Tên không được dài hơn 20 kí tự.")]
        public string CategoryName { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public CommonEnum Status { get; set; }
        public  ICollection<Course> Courses { get;  } = new List<Course>();
    }
}
