﻿using Devify.Entity;

namespace Devify.Models
{
    public class Detail_Course
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
        public string Image { get; set; }
        public virtual Detail_Course_Creator Creator { get; set; }
        public virtual IEnumerable<Detail_Course_LanguageList> Languages { get; set; } = new List<Detail_Course_LanguageList>();
        public virtual IEnumerable<Detail_Course_ChapterList> Chapters { get; set; } = new List<Detail_Course_ChapterList>();
        public virtual IEnumerable<Detail_Course_CategoryList> Categories { get; set; } = new List<Detail_Course_CategoryList>();
    }
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
    public class Detail_Course_Creator
    {
        public Guid CreatorId { get; set;}
        public string Name { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
    public class Detail_Course_LanguageList
    {
        public string LanguageId { get; set; }
        public string Name { get; set; }

    }
    public class Detail_Course_CategoryList
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class All_Course_List
    {
        public virtual IEnumerable<All_Course_Item> courseItems { get; set; } = new List<All_Course_Item>();
    }
    public class All_Course_Item
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        public string? Link { get; set; }
        public string Image { get; set; }
        public virtual Detail_Course_Creator Creator { get; set; }
        public virtual IEnumerable<Detail_Course_LanguageList> Languages { get; set; } = new List<Detail_Course_LanguageList>();
        public virtual IEnumerable<Detail_Course_CategoryList> Categories { get; set; } = new List<Detail_Course_CategoryList>();
    }
}
