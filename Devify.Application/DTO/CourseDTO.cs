using Devify.Entity;

namespace Devify.Application.DTO
{
    // ================================================================================================
    // ======================================= Container DTO ==========================================
    public class All_Course_List
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        public string? Slug { get; set; }
        public string Image { get; set; }
        public  Detail_Course_Creator Creator { get; set; }
        public  IEnumerable<Detail_Course_LanguageList> CourseLanguages { get; set; } = new List<Detail_Course_LanguageList>();       
    }

    public class Detail_Course_DTO
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string? Slug { get; set; }
        public string Image { get; set; }   
        public int TotalChapter => Chapters.Count();
        public int TotalLesson => Chapters.Sum(chapter => chapter.Lessons.Count());
        public Detail_Course_Creator Creator { get; set; }
        public Detail_Course_Category Category { get; set; }
        public  IEnumerable<Detail_Course_LanguageList> CourseLanguages { get; set; } = new List<Detail_Course_LanguageList>();
        public  IEnumerable<Detail_Course_ChapterList> Chapters { get; set; } = new List<Detail_Course_ChapterList>();

    }
    // ===========================================================================================
    // ======================================= Item DTO ==========================================
    public class Detail_Course_ChapterList
    {
        public Guid ChapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Detail_Course_LessonList> Lessons { get; set; } = new List<Detail_Course_LessonList>();
    }
    public class Detail_Course_LessonList
    {
        public Guid LessonId { get; set; }
        public string Name { get; set; }
    }

    public class Detail_Course_LanguageList
    {
        public string LanguageId { get; set; }
        public string Name { get; set; }

    }

    public class Detail_Course_Creator
    {
        public string CreatorId { get; set; }
        public string DisplayName { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
    }
   
    public class Detail_Course_Category
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
