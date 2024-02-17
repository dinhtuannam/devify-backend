using Devify.Application.Interfaces;
using Devify.Entity;
using Microsoft.AspNetCore.Http;

namespace Devify.Application.DTO
{
    public class CourseItem
    {
        public string code { get; set; } = "";
        public string title { get; set; } = "";
        public long purchases { get; set; } = 0;
        public double price { get; set; } = 0;
        public double salePrice { get; set; } = 0;
        public string des { get; set; } = "";
        public string image { get; set; } = "";
        public bool isactivated { get; set; } = false;
        public bool issale { get; set; } = false;
        public string createTime { get; set; } = "";
        public string updateTime { get; set; } = "";
        public CourseCreatorAttribute creator { get; set; } = new CourseCreatorAttribute();
        public CourseAttribute category { get; set; } = new CourseAttribute();
        public List<CourseAttribute> languages { get; set; } = new List<CourseAttribute>();
        public List<CourseAttribute> level { get; set; } = new List<CourseAttribute>();
    }

    public class DetailCourseDTO
    {
        public string code { get; set; } = "";
        public string title { get; set; } = "";
        public long purchases { get; set; } = 0;
        public double price { get; set; } = 0;
        public double salePrice { get; set; } = 0;
        public string des { get; set; } = "";
        public string image { get; set; } = "";
        public bool isactivated { get; set; } = false;
        public bool issale { get; set; } = false;
        public bool owner { get; set; } = false;
        public string createTime { get; set; } = "";
        public string updateTime { get; set; } = "";
        public CourseCreatorAttribute creator { get; set; } = new CourseCreatorAttribute();
        public CourseAttribute category { get; set; } = new CourseAttribute();
        public List<CourseAttribute> languages { get; set; } = new List<CourseAttribute>();
        public List<CourseAttribute> level { get; set; } = new List<CourseAttribute>();
        public List<DetailChapterDTO> chapters { get; set; } = new List<DetailChapterDTO>();
    }

    public class CourseAttribute
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
    }

    public class CourseCreatorAttribute
    {
        public string code { get; set; } = "";
        public string displayName { get; set; } = "";
        public string username { get; set; } = "";
        public string image { get; set; } = "";
    }

    public class CourseLearningInfo
    {
        public string code { get; set; } = "";
        public string title { get; set; } = "";
        public string des { get; set; } = "";
        public string image { get; set; } = "";
        public string createTime { get; set; } = "";
        public string updateTime { get; set; } = "";
        public bool isOwner { get; set; } = false;
        public int totalChapter { get; set; } = 0;
        public int totalLesson { get; set; } = 0;
        public CourseCreatorAttribute creator { get; set; } = new CourseCreatorAttribute();
        public List<DetailChapterDTO> chapters { get; set; } = new List<DetailChapterDTO>();

    }

}
