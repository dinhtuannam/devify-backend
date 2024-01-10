using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ICourseRepository : IGenericRepository<SqlCourse>
    {
        Task<DetailCourseDTO> GetCourseBySlug(string slug);
        Task<LearningCourseDTO> GetLearningCourse(string slug);
        Task<LearningLessonDTO> GetLearningLesson(string slug,Guid LessonId);
        Task<DataListDTO<IEnumerable<AllCourseList>>> GetAllCourse();
        Task<DataListDTO<IEnumerable<SearchCourseList>>> SearchCourse(CourseSearchParams parameters);

    }
}
