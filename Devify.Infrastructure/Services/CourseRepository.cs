using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Devify.Infrastructure.Services
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IUnitOfWork _unitOfWork;
        public CourseRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _DbContext = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<DataListDTO<IEnumerable<AllCourseList>>> GetAllCourse()
        {
            var dataList = new DataListDTO<IEnumerable<AllCourseList>>();
            try
            {               
                var query = await _context.Courses.AsNoTracking()
                    .Include(c => c.Creator).ThenInclude(c => c.User)
                    .Include(c => c.CourseLanguages).ThenInclude(cl => cl.Language)
                    .ToListAsync();
                dataList.Items = query.Select(c => new AllCourseList
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Purchased = c.Purchased,
                    Price = c.Price,
                    Slug = c.Slug,
                    Image = c.Image,
                    Creator = new DetailCourseCreator
                    {
                        CreatorId = c.Creator.CreatorId,
                        DisplayName = c.Creator.User.DisplayName,
                        Slug = c.Creator.Slug,
                        Image = c.Creator.User.Image
                    },
                    CourseLanguages = c.CourseLanguages.Select(cl => new DetailCourseLanguageList
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

        public async Task<DetailCourseDTO> GetCourseBySlug(string slug)
        {
            try
            {
                var query = await _context.Courses.AsNoTracking()
                        .Include(c => c.Creator).ThenInclude(c => c.User)
                        .Include(c => c.Chapters.OrderBy(c => c.Step)).ThenInclude(c => c.Lessons.OrderBy(l => l.Step))
                        .Include(c => c.Category)
                        .Include(c => c.CourseLanguages).ThenInclude(cl => cl.Language)
                        .Where(c => c.Slug == slug).FirstOrDefaultAsync();
                if (query == null)
                    return null;
                var course = new DetailCourseDTO
                {
                    CourseId = query.CourseId,
                    Title = query.Title,
                    Purchased = query.Purchased,
                    Price = query.Price,
                    Description = query.Description,
                    Slug = query.Slug,
                    Image = query.Image,
                    Creator = new DetailCourseCreator
                    {
                        CreatorId = query.Creator.CreatorId,
                        DisplayName = query.Creator.User.DisplayName,
                        Slug = query.Creator.Slug,
                        Image = query.Creator.User.Image
                    },
                    Category = new DetailCourseCategory
                    {
                        CategoryId = query.Category.CategoryId,
                        CategoryName = query.Category.CategoryName,
                    },
                    CourseLanguages = query.CourseLanguages.Select( item => new DetailCourseLanguageList
                    {
                        LanguageId = item.Language.LanguageId,
                        Name = item.Language.Name
                    }),
                    Chapters = query.Chapters.Select( item => new DetailCourseChapterList
                    {
                        ChapterId = item.ChapterId,
                        Name = item.Name,
                        Description = item.Description,
                        Lessons = item.Lessons.Select( lsItem => new DetailCourseLessonList
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

        public async Task<LearningCourseDTO> GetLearningCourse(string slug)
        {
            try
            {
                var query = await _context.Courses
                    .Include(c => c.Chapters.OrderBy(c => c.Step)).ThenInclude(c => c.Lessons.OrderBy(l => l.Name))
                    .Where(c => c.Slug == slug).FirstOrDefaultAsync();
                if (query == null)
                    return null;
                var course = new LearningCourseDTO
                {
                    CourseId = query.CourseId,
                    Title = query.Title,
                    Description = query.Description,
                    Slug = query.Slug,
                    Image = query.Image,
                    Chapters = query.Chapters.Select(item => new DetailCourseChapterList
                    {
                        ChapterId = item.ChapterId,
                        Name = item.Name,
                        Description = item.Description,
                        Lessons = item.Lessons.Select(lsItem => new DetailCourseLessonList
                        {
                            LessonId = lsItem.LessonId,
                            Name = lsItem.Name
                        })
                    })
                };
                Console.WriteLine($"[CourseService] -> GetLearningCourse width slug: {slug} -> successfully");
                return course;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CourseService] -> GetLearningCourse -> failed , Exception: {ex.Message}");
                return null;
            }
        }

        public override async Task<bool> AddAsAsync(Course course)
        {
            try
            {
                var result = await _dbSet.AddAsync(course);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CourseService] -> AddAsAsync -> failed , Exception: {ex.Message}");
                return false;
            }
        }

        public async Task<LearningLessonDTO> GetLearningLesson(string slug, Guid LessonId)
        {
            try
            {               
                var lesson = await _unitOfWork.LessonRepository.GetByCondition(condition: ls => ls.LessonId == LessonId)
                .Include(ls => ls.Chapter).ThenInclude(ch => ch.Course)
                .Select(ls => new LearningLessonDTO
                {
                    LessonId = ls.LessonId,
                    Name = ls.Name,
                    Description = ls.Description,
                    Video = ls.Video,
                    CourseId = ls.Chapter.CourseId,
                })
                .FirstOrDefaultAsync();
                if(lesson == null)
                {
                    return null;
                }
                var course = await _unitOfWork.CourseRepository.GetByCondition(condition: c => c.Slug == slug)
                     .Include(c => c.Creator)
                     .Select(c => new Course
                     {
                         CourseId = c.CourseId,
                         Title = c.Title,
                         Slug = c.Slug,
                     }).FirstOrDefaultAsync();
                if (course == null)
                {
                    return null;
                }
                if (lesson.CourseId == course.CourseId)
                {
                    lesson.CourseTitle = course.Title;
                    lesson.CourseSlug = course.Slug;
                    return lesson;

                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<DataListDTO<IEnumerable<SearchCourseList>>> SearchCourse(CourseSearchParams parameters)
        {
            var dataList = new DataListDTO<IEnumerable<SearchCourseList>>();
            var query = _context.Courses.AsQueryable().Where(course => course.Status == "1");
                          
            if(parameters.category != null && parameters.category.Count > 0 )
            {
                query = query.Where(course => course.Category != null && parameters.category.Contains(course.Category.CategoryName));
            }
            if (parameters.level != null && parameters.level.Count > 0)
            {
                query = query.Where(course => course.CourseLevel != null && parameters.level.Contains(course.CourseLevel.LevelName));
            }
            if (parameters.language != null && parameters.language.Count > 0)
            {
                query = query.Where(course => course.CourseLanguages
                .Any(cl => parameters.language.Contains(cl.Language.Name)));
            }
            if (!string.IsNullOrEmpty(parameters.query))
            {
                query = query.Where(course => course.Title.Contains(parameters.query));
            }
            dataList.Items = await query
                .Include(c => c.Creator).ThenInclude(c => c.User)
                .Include(c => c.CourseLanguages).ThenInclude(cl => cl.Language)
                .Include(c => c.Category)
                .Skip(parameters.pageSize * (parameters.page-1) )
                .Take(parameters.pageSize)
                .Select(c => new SearchCourseList
            {
                CourseId = c.CourseId,
                Title = c.Title,
                Purchased = c.Purchased,
                Price = c.Price,
                Slug = c.Slug,
                Image = c.Image,
                Creator = new DetailCourseCreator
                {
                    CreatorId = c.Creator.CreatorId,
                    DisplayName = c.Creator.User.DisplayName,
                    Slug = c.Creator.Slug,
                    Image = c.Creator.User.Image
                },
                CourseCategory = new DetailCourseCategory
                {
                    CategoryId = c.Category.CategoryId,
                    CategoryName = c.Category.CategoryName
                },
                CourseLevel = new DetailCourseLevel
                {
                    CourseLevelId = c.CourseLevel.CourseLevelId,
                    LevelName = c.CourseLevel.LevelName
                },
                CourseLanguages = c.CourseLanguages.Select(cl => new DetailCourseLanguageList
                {
                    LanguageId = cl.Language.LanguageId,
                    Name = cl.Language.Name
                }).ToList()
            }).ToListAsync();
            dataList.TotalRecords = query.Count();
            Console.WriteLine($"[CourseService] -> GetAllCourseAsync -> success ");
            return dataList;
        }
    }
}
