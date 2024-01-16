
namespace Devify.Application.DTO
{
    public class ChapterItem
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public int step { get; set; } = 0;
        public bool isactivated { get; set; } = false;
        public string createTime { get; set; } = "";
        public string updateTime { get; set; } = "";
    }

    public class DetailChapterDTO
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public int step { get; set; } = 0;
        public bool isactivated { get; set; } = false;
        public string createTime { get; set; } = "";
        public string updateTime { get; set; } = "";
        public List<DetailLessonDTO> lessons { get; set; } = new List<DetailLessonDTO>();
    }
}
