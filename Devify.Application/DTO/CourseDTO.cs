using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class All_Course_List
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        public string? Link { get; set; }
        public string Image { get; set; }
        public  Detail_Course_Creator Creator { get; set; }
        public  IEnumerable<Detail_Course_LanguageList> CourseLanguages { get; set; } = new List<Detail_Course_LanguageList>();       
    }

    public class Detail_Course_LanguageList
    {
        public string LanguageId { get; set; }
        public string Name { get; set; }

    }
    public class Detail_Course_Creator
    {
        public Guid CreatorId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
    }
}
