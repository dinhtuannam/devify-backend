using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class ChapterRepository : GenericRepository<SqlChapter>, IChapterRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChapterRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SqlChapter> CreateChapter(string course, string name, string des, int step)
        {
            SqlCourse? m_course = _unitOfWork.course.GetRawEntityByCode(course);
            if (m_course == null || m_course.isdeleted == true)
            {
                return new SqlChapter();
            }
            SqlChapter chapter = new SqlChapter
            {
                id = DateTime.Now.Ticks,
                code = new Guid().ToString(),
                name = name,
                des = des,
                step = step,
                course = m_course
            };
            _unitOfWork.chapter.Insert(chapter);
            return await _unitOfWork.CompleteAsync() > 0 ? chapter : new SqlChapter();
        }

        public async Task<bool> DeleteChapter(string code)
        {
            SqlChapter? chapter = _unitOfWork.chapter.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false)
                                                     .Include(s => s.lessons)
                                                     .FirstOrDefault();
            if (chapter == null)
            {
                return false;
            }
            chapter.isdeleted = true;
            foreach(SqlLesson ls in chapter.lessons!)
            {
                ls.isdeleted = true;
            }
            return await _unitOfWork.CompleteAsync() > 0 ;
        }

        public ChapterItem GetChapter(string code)
        {
            ChapterItem dto = new ChapterItem();
            SqlChapter? chapter = _unitOfWork.chapter.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false)
                                                      .FirstOrDefault();
            if (chapter == null)
            {
                return dto;
            }

            dto.code = chapter.code;
            dto.name = chapter.name;
            dto.des = chapter.des;
            dto.step = chapter.step;
            dto.isactivated = chapter.isactivated;
            dto.createTime = chapter.DateCreated.ToString("dd-mm-yyy hh:mm:ss");
            dto.updateTime = chapter.DateUpdated.ToString("dd-mm-yyy hh:mm:ss");

            return dto;
        }

        public DetailChapterDTO GetDetailChapter(string code)
        {
            DetailChapterDTO dto = new DetailChapterDTO();
            SqlChapter? chapter = _unitOfWork.chapter.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false)
                                                     .Include(s => s.lessons)
                                                     .FirstOrDefault();
            if (chapter == null)
            {
                return dto;
            }

            dto.code = chapter.code;
            dto.name = chapter.name;
            dto.des = chapter.des;
            dto.step = chapter.step;
            dto.isactivated = chapter.isactivated;
            dto.createTime = chapter.DateCreated.ToString("dd-mm-yyy hh:mm:ss");
            dto.updateTime = chapter.DateUpdated.ToString("dd-mm-yyy hh:mm:ss");

            foreach(SqlLesson ls in chapter.lessons!)
            {
                if(ls.isdeleted == false)
                {
                    DetailLessonDTO lesson = new DetailLessonDTO
                    {
                        code = ls.code,
                        name = ls.name,
                        des = ls.des,
                        step = ls.step,
                        video = ls.video,
                        image = ls.image,
                        createTime = ls.DateCreated.ToString("dd-mm-yyy hh:mm:ss"),
                        updateTime = ls.DateUpdated.ToString("dd-mm-yyy hh:mm:ss")
                    };
                    dto.lessons.Add(lesson);
                }
            }

            return dto;
        }

        public List<ChapterItem> GetListChapterByCourse(string code)
        {
            List<ChapterItem> list = new List<ChapterItem>();
            SqlCourse? m_course = _unitOfWork.course.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false)
                                                    .Include(s => s.chapters)
                                                    .FirstOrDefault();

            if (m_course == null || m_course.isdeleted == true)
            {
                return list;
            }
            foreach(SqlChapter ch in m_course.chapters!)
            {
                if(ch.isdeleted == false)
                {
                    ChapterItem item = new ChapterItem();
                    item.code = ch.code;
                    item.name = ch.name;
                    item.des = ch.des;
                    item.step = ch.step;
                    item.isactivated = ch.isactivated;
                    item.createTime = ch.DateCreated.ToString("dd-mm-yyy hh:mm:ss");
                    item.updateTime = ch.DateUpdated.ToString("dd-mm-yyy hh:mm:ss");
                    list.Add(item);
                }
            }
            return list.OrderBy(s => s.step).ToList();
        }

        public async Task<SqlChapter> UpdateChapter(string code, string name, string des, int step)
        {
            SqlChapter? chapter = _unitOfWork.chapter.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false)
                                                     .Include(s => s.lessons)
                                                     .FirstOrDefault();
            if (chapter == null)
            {
                return new SqlChapter();
            }

            chapter.name = name;
            chapter.des = des;
            chapter.step = chapter.step;
            chapter.DateUpdated = DateTime.Now;

            return await _unitOfWork.CompleteAsync() > 0 ? chapter : new SqlChapter();
        }
    }
}
