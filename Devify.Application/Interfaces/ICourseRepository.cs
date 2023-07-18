using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<Detail_Course_DTO> GetCourseBySlug(string slug);
        Task<DataListDTO<IEnumerable<All_Course_List>>> GetAllCourse();
    }
}
