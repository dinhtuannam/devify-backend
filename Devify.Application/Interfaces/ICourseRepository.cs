using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<DetailCourseDTO> GetCourseBySlug(string slug);
        Task<DataListDTO<IEnumerable<AllCourseList>>> GetAllCourse();
    }
}
