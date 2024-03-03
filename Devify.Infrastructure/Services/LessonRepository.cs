using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class LessonRepository : GenericRepository<SqlLesson>, ILessonRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public LessonRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SqlLesson> createLesson(string chapter, string name, string des, int step)
        {
            SqlChapter? m_chapter = _unitOfWork.chapter.GetCondition(s => s.code.CompareTo(chapter) == 0 && s.isdeleted == false && s.course != null)
                                                       .Include(s => s.course)
                                                       .FirstOrDefault();

            if (m_chapter == null)
            {
                return new SqlLesson();
            }
            SqlLesson lesson = new SqlLesson
            {
                id = DateTime.Now.Ticks,
                code = new Guid().ToString(),
                name = name,
                des = des,
                step = step,
                video = ConfigKey.DEFAULT_COURSE_VIDEO,
                image = ConfigKey.DEFAULT_COURSE_BG,
                course = m_chapter.course,
                chapter = m_chapter
            };
            _unitOfWork.lesson.Insert(lesson);
            return await _unitOfWork.CompleteAsync() > 0 ? lesson : new SqlLesson();
        }

        public async Task<bool> deleteLesson(string code)
        {
            SqlLesson? lesson = _unitOfWork.lesson.GetRawEntityByCode(code);
            if(lesson == null || lesson.isdeleted == true)
            {
                return false;
            }
            lesson.isdeleted = true;
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public List<DetailLessonDTO> getAllLesson()
        {
            List<DetailLessonDTO> list = new List<DetailLessonDTO>();
            List<SqlLesson> lessons = _unitOfWork.lesson.GetAll().Where(s => s.isdeleted == false).OrderBy(s => s.step).ToList();
            foreach(SqlLesson lesson in lessons)
            {
                DetailLessonDTO item = new DetailLessonDTO();
                item.code = lesson.code;
                item.name = lesson.name;
                item.des = lesson.des;
                item.step = lesson.step;
                item.image = lesson.image;
                item.video = lesson.video;
                item.createTime = lesson.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                item.updateTime = lesson.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                list.Add(item);
            }
            return list;
        }

        public List<DetailLessonDTO> getAllLessonByCourse(string course)
        {
            List<DetailLessonDTO> list = new List<DetailLessonDTO>();
            List<SqlLesson> lessons = _unitOfWork.lesson.GetAll()
                                                        .Where(s => s.isdeleted == false && s.course != null && s.course.code.CompareTo(course) == 0)
                                                        .OrderBy(s => s.step).ToList();
            foreach (SqlLesson lesson in lessons)
            {
                DetailLessonDTO item = new DetailLessonDTO();
                item.code = lesson.code;
                item.name = lesson.name;
                item.des = lesson.des;
                item.step = lesson.step;
                item.image = lesson.image;
                item.video = lesson.video;
                item.createTime = lesson.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                item.updateTime = lesson.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                list.Add(item);
            }
            return list;
        }

        public DetailLessonDTO getDetailLesson(string code)
        {
            SqlLesson? lesson = _unitOfWork.lesson.GetAll()
                                                  .Where(s => s.isdeleted == false && s.code.CompareTo(code) == 0)
                                                  .OrderBy(s => s.step).FirstOrDefault();

            if(lesson == null)
            {
                return new DetailLessonDTO();
            }

            DetailLessonDTO item = new DetailLessonDTO();
            item.code = lesson.code;
            item.name = lesson.name;
            item.des = lesson.des;
            item.step = lesson.step;
            item.image = lesson.image;
            item.video = lesson.video;
            item.createTime = lesson.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
            item.updateTime = lesson.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
            
            return item;
        }

        public async Task<SqlLesson> updateLesson(string code, string name, string des, int step)
        {
            SqlLesson? lesson = _unitOfWork.lesson.GetRawEntityByCode(code);
            if (lesson == null || lesson.isdeleted == true)
            {
                return new SqlLesson();
            }
            lesson.name = name;
            lesson.des = des;
            lesson.step = step;
            lesson.DateUpdated = DateTime.Now;

            return await _unitOfWork.CompleteAsync() > 0 ? lesson : new SqlLesson();
        }
    }
}
