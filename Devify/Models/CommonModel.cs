namespace Devify.Models
{
    public class SearchParam
    {
        private int _page = 1;
        private int _pageSize = 12;

        public string? query { get; set; }

        public int page
        {
            get { return _page; }
            set { _page = (value != 0) ? value : 1; }
        }

        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value != 0) ? value : 12; }
        }
    }

    public class CourseSearchParam : SearchParam
    {
        public string query { get; set; } = "";
        public List<string> cat { get; set; } = new List<string>();
        public List<string> lang { get; set; } = new List<string>();
        public List<string> lvl { get; set; } = new List<string>();
    }
}
