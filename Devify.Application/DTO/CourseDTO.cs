using Devify.Entity;
using Devify.Entity.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

    public class SearchCourseList
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        public string? Slug { get; set; }
        public string Image { get; set; }
        public DetailCourseCreator Creator { get; set; }
        public DetailCourseCategory CourseCategory { get; set; }
        public DetailCourseLevel CourseLevel { get; set; }
        public IEnumerable<DetailCourseLanguageList> CourseLanguages { get; set; } = new List<DetailCourseLanguageList>();
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

    public class DetailCourseLevel
    {
        public string CourseLevelId { get; set; }
        public string LevelName { get; set; }
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

    public class UpdateCourseRequest
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public IFormFile Image { get; set; }
        public string CategoryId { get; set; }
        public string CourseLevelId { get; set; }
    }

    public class CreateCourseChapterRequest
    {
        public string Name { get; set; }
        public int? Step { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateCourseChapterRequest
    {
        public Guid ChapterId { get; set; }
        public string Name { get; set; }
        public int? Step { get; set; }
        public string? Description { get; set; }
        public CommonEnum Status { get; set; }

    }

    public class CreateCourseLessonRequest
    {
        public string Name { get; set; }
        public int? Step { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateCourseLessonRequest
    {
        public Guid ChapterId { get; set; }
        public string Name { get; set; }
        public int? Step { get; set; }
        public string? Description { get; set; }
        public CommonEnum Status { get; set; }

    }

    // ====================================== Learning Course DTO =======================================
    public class LearningCourseDTO
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Slug { get; set; }
        public string Image { get; set; }
        public int TotalChapter => Chapters.Count();
        public int TotalLesson => Chapters.Sum(chapter => chapter.Lessons.Count());
        public IEnumerable<DetailCourseChapterList> Chapters { get; set; } = new List<DetailCourseChapterList>();

    }

    public class LearningLessonDTO
    {
        public Guid LessonId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Video { get; set; }
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string? CourseSlug { get; set; }
    }


}
