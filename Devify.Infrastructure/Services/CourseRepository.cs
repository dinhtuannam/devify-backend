using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;


namespace Devify.Infrastructure.Services
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public CourseRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<DataListDTO<IEnumerable<All_Course_List>>> GetAllCourse()
        {
            var dataList = new DataListDTO<IEnumerable<All_Course_List>>();
            try
            {               
                var query = await _context.Courses.AsNoTracking()
                    .Include(c => c.Creator).ThenInclude(c => c.User)
                    .Include(c => c.CourseLanguages).ThenInclude(cl => cl.Language)
                    .ToListAsync();
                dataList.Items = query.Select(c => new All_Course_List
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Purchased = c.Purchased,
                    Price = c.Price,
                    Slug = c.Slug,
                    Image = c.Image,
                    Creator = new Detail_Course_Creator
                    {
                        CreatorId = c.Creator.CreatorId,
                        DisplayName = c.Creator.User.DisplayName,
                        Slug = c.Creator.Slug,
                        Image = c.Creator.User.Image
                    },
                    CourseLanguages = c.CourseLanguages.Select(cl => new Detail_Course_LanguageList
                    {
                        LanguageId = cl.Language.LanguageId,
                        Name = cl.Language.Name
                    }).ToList()
                });
                dataList.TotalRecords = query.Count;
                Console.WriteLine($"[CourseService] -> GetAllCourseAsync -> success ");
                return dataList;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[CourseService] -> GetAllCourseAsync -> failed , Exception: {ex.Message}");
                dataList.Items = null;
                dataList.TotalRecords = 0;
                return dataList;
            }
            
        }

        public async Task<Detail_Course_DTO> GetCourseBySlug(string slug)
        {
            try
            {
                var query = await _context.Courses.AsNoTracking()
                        .Include(c => c.Creator).ThenInclude(c => c.User)
                        .Include(c => c.Chapters.OrderBy(c => c.Name)).ThenInclude(c => c.Lessons.OrderBy(l => l.Name))
                        .Include(c => c.Category)
                        .Include(c => c.CourseLanguages).ThenInclude(cl => cl.Language)
                        .Where(c => c.Slug == slug).FirstOrDefaultAsync();
                if (query == null)
                    return null;
                var course = new Detail_Course_DTO
                {
                    CourseId = query.CourseId,
                    Title = query.Title,
                    Purchased = query.Purchased,
                    Price = query.Price,
                    Description = query.Description,
                    Slug = query.Slug,
                    Image = query.Image,
                    Creator = new Detail_Course_Creator
                    {
                        CreatorId = query.Creator.CreatorId,
                        DisplayName = query.Creator.User.DisplayName,
                        Slug = query.Creator.Slug,
                        Image = query.Creator.User.Image
                    },
                    Category = new Detail_Course_Category
                    {
                        CategoryId = query.Category.CategoryId,
                        CategoryName = query.Category.CategoryName,
                    },
                    CourseLanguages = query.CourseLanguages.Select( item => new Detail_Course_LanguageList
                    {
                        LanguageId = item.Language.LanguageId,
                        Name = item.Language.Name
                    }),
                    Chapters = query.Chapters.Select( item => new Detail_Course_ChapterList
                    {
                        ChapterId = item.ChapterId,
                        Name = item.Name,
                        Description = item.Description,
                        Lessons = item.Lessons.Select( lsItem => new Detail_Course_LessonList
                        {
                            LessonId = lsItem.LessonId,
                            Name = lsItem.Name
                        })
                    })
                };
                Console.WriteLine($"[CourseService] -> GetCourseBySlug width slug: {slug} -> successfully");
                return course;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CourseService] -> GetCourseBySlug -> failed , Exception: {ex.Message}");
                return null;
            }
            
        }

        public override async Task<bool> AddAsAsync(Course course)
        {
            try
            {
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CourseService] -> AddAsAsync -> failed , Exception: {ex.Message}");
                return false;
            }
        }
    }
}
