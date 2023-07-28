using Devify.Entity;
using Microsoft.AspNetCore.Http;

namespace Devify.Application.DTO
{
    // ================================================================================================
    // ======================================= Container DTO ==========================================
    public class AllCourseList
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        public string? Slug { get; set; }
        public string Image { get; set; }
        public  DetailCourseCreator Creator { get; set; }
        public  IEnumerable<DetailCourseLanguageList> CourseLanguages { get; set; } = new List<DetailCourseLanguageList>();       
    }

    public class DetailCourseDTO
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
        public DetailCourseCreator Creator { get; set; }
        public DetailCourseCategory Category { get; set; }
        public  IEnumerable<DetailCourseLanguageList> CourseLanguages { get; set; } = new List<DetailCourseLanguageList>();
        public  IEnumerable<DetailCourseChapterList> Chapters { get; set; } = new List<DetailCourseChapterList>();

    }
    // ===========================================================================================
    // ======================================= Item DTO ==========================================
    public class DetailCourseChapterList
    {
        public Guid ChapterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<DetailCourseLessonList> Lessons { get; set; } = new List<DetailCourseLessonList>();
    }
    public class DetailCourseLessonList
    {
        public Guid LessonId { get; set; }
        public string Name { get; set; }
    }

    public class DetailCourseLanguageList
    {
        public string LanguageId { get; set; }
        public string Name { get; set; }

    }

    public class DetailCourseCreator
    {
        public string CreatorId { get; set; }
        public string DisplayName { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
    }
   
    public class DetailCourseCategory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }


    // ==============================================================================================
    // ======================================= Command DTO ==========================================

    public class CreateCourseRequest
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public string Status { get; set; }
        public IFormFile Image { get; set; }
        public string CreatorId { get; set; }
        public string CategoryId { get; set; }
        public string CourseLevelId { get; set; }
    }

}
