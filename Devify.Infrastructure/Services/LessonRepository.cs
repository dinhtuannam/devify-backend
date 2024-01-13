using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;


namespace Devify.Infrastructure.Services
{
    public class LessonRepository : GenericRepository<SqlLesson>, ILessonRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public LessonRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public List<LessonItem> getAllLesson()
        {
            List<LessonItem> list = new List<LessonItem>();
            List<SqlLesson> lessons = _unitOfWork.lesson.GetAll().Where(s => s.isdeleted == false).ToList();
            foreach(SqlLesson lesson in lessons)
            {
                LessonItem item = new LessonItem();
                item.code = lesson.code;
                item.name = lesson.name;
                item.des = lesson.des;
                item.step = lesson.step;
                item.image = lesson.image;
                item.video = lesson.video;
                item.createDate = lesson.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                list.Add(item);
            }
            return list;
        }
    }
}
