using Devify.Application.DTO;
using Devify.Entity;
using Devify.Entity.Enums;
using System.Diagnostics;

namespace Devify.Application.Interfaces
{
    public interface ICourseRepository : IGenericRepository<SqlCourse>
    {
        DetailCourseDTO GetCourse(string code, bool? privateData = true);
        List<CourseItem> GetUserInventory(string code, SortDateEnum sort);
        DataList<CourseItem> GetCreatorCourse(string creator, int page, int size, string title);
        DataList<CourseItem> GetAllCourse(int page,int pageSize,string title,List<string> cat,List<string> lang,List<string> lvl);
        Task<SqlCourse> createCourse(string user,string title, string des, double price, double salePrice, bool issale,string category, List<string> lang, List<string> lvl);
        Task<SqlCourse> updateCourse(string code,string title, string des, double price, double salePrice, bool issale, string category, List<string> lang, List<string> lvl);
        CourseLearningInfo getLearningCourseInfo(string code,string? user = "");
        Task<bool> deleteCourse(string code);
        List<string> GetListProductCodeBoughtByUser(string user);
    }
}
