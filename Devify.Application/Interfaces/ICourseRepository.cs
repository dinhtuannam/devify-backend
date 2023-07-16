using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseBySlug(string slug);
        Task<List<Course>> GetAllCourse();
    }
}
