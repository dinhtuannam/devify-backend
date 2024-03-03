using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ILessonRepository : IGenericRepository<SqlLesson>
    {
        public List<DetailLessonDTO> getAllLesson();
        public List<DetailLessonDTO> getAllLessonByCourse(string course);
        public DetailLessonDTO getDetailLesson(string code);
        public Task<SqlLesson> createLesson(string chapter,string name, string des,int step);
        public Task<SqlLesson> updateLesson(string code,string name, string des, int step);
        public Task<bool> deleteLesson(string code);
    }
}
