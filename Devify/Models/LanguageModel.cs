using System.ComponentModel.DataAnnotations;

namespace Devify.Models
{
    public class CreateLanguageModel
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
    }

    public class UpdateLanguageModel
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
    }
}
