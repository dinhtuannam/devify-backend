﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}