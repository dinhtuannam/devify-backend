using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;


namespace Devify.Infrastructure.Services
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCourse()
        {
            return _context.Courses
                .Include(c => c.Creator)
                .Include(c => c.CourseLanguages).ThenInclude(cl => cl.Language)
                .ToList();
        }

        public async Task<Course> GetCourseBySlug(string slug)
        {
            var courses = await _context.Courses.AsNoTracking()
                .Include(c => c.Creator).ThenInclude(c => c.User)
                .Include(c => c.Chapters.OrderBy(c => c.Name)).ThenInclude(c => c.Lessons.OrderBy(l => l.Name))
                .Include(c => c.Category)
                .Include(c => c.CourseLanguages).ThenInclude(cl => cl.Language)
                .Where(c => c.Slug == slug).ToListAsync();
            return courses.FirstOrDefault();
        }
    }
}
