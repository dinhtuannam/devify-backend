using Devify.Application;
using Devify.Entity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Devify.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourse()
        {
            return  _context.Courses
                .Include(c => c.Creator)
                .Include(c => c.CourseLanguages).ThenInclude(cl => cl.Language)
                .Include(c => c.CourseCategories).ThenInclude(cc => cc.Category)
                .ToList();
        }

        public Course GetCourseByName(string name)
        {
            var result = _context.Courses
                .Include(c => c.Creator)
                .Include(c => c.Chapters).ThenInclude(c => c.Lessons.OrderBy(l=> l.Name))
                .Include(c => c.CourseLanguages).ThenInclude(cl => cl.Language)
                .Include(c => c.CourseCategories).ThenInclude(cc => cc.Category)
                .Where(c=> c.Link == name)
                .FirstOrDefault();
            return result;
        }
    }
}
