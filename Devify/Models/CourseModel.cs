namespace Devify.Models
{
    public class CreateCourseModel
    {
        public string title { get; set; } = "";
        public string des { get; set; } = "";
        public double price { get; set; } = 0;
        public double salePrice { get; set; } = 0;
        public string category { get; set; } = "";
        public bool issale { get; set; } = false;
        public List<string> languages { get; set; } = new List<string>();
        public List<string> levels { get; set; } = new List<string>();
    }

    public class UpdateCourseModel
    {
        public string code { get; set; } = "";
        public string title { get; set; } = "";
        public string des { get; set; } = "";
        public double price { get; set; } = 0;
        public double salePrice { get; set; } = 0;
        public string category { get; set; } = "";
        public bool issale { get; set; } = false;
    }
}
