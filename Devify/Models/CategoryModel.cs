using System.ComponentModel.DataAnnotations;

namespace Devify.Models
{
    public class CreateCategoryModel
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
    }

    public class UpdateCategoryModel
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
    }
}
