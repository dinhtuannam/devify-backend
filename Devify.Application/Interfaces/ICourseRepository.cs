using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface ICourseRepository
    {
        Course GetCourseByName(string name);
        List<Course> GetAllCourse();
    }
}
