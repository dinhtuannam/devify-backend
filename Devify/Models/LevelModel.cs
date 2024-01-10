using Devify.Entity;
using System.ComponentModel.DataAnnotations;

namespace Devify.Models
{
    public class CreateLevelModel
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
    }

    public class UpdateLevelModel
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";

    }
}
