using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Entity.Enums;
using Devify.Infrastructure.Helpers;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class CourseRepository : GenericRepository<SqlCourse>, ICourseRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public DetailCourseDTO GetCourse(string code,bool? privateData = true)
        {
            DetailCourseDTO item = new DetailCourseDTO();
            SqlCourse? course = _unitOfWork.course.GetCode(code, 0)
                                                  .Include(s => s.category)
                                                  .Include(s => s.languages)
                                                  .Include(s => s.levels)
                                                  .Include(s => s.user)
                                                  .Include(s => s.chapters!).ThenInclude(s => s.lessons!)
                                                  .FirstOrDefault();
            if(course == null)
            {
                return item;
            }

            item.code = course.code;
            item.title = course.title;
            item.price = course.price;
            item.purchases = course.purchases;
            item.salePrice = course.salePrice;
            item.issale = course.issale;
            item.isactivated = course.isactivated;
            item.des = course.des;
            item.image = course.image;
            item.createTime = course.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
            item.updateTime = course.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");

            if (course.category != null && course.category.isdeleted == false)
            {
                item.category.code = course.category.code;
                item.category.name = course.category.name;
                item.category.des = course.category.des;
            }

            if (course.user != null && course.user.isdeleted == false)
            {
                item.creator.code = course.user.code;
                item.creator.username = course.user.username;
                item.creator.displayName = course.user.displayName;
                item.creator.image = course.user.image;
            }

            if (course.languages != null)
            {
                foreach (SqlLanguage l in course.languages)
                {
                    if (l.isdeleted == false)
                    {
                        CourseAttribute attr = new CourseAttribute();
                        attr.code = l.code;
                        attr.name = l.name;
                        attr.des = l.des;
                        item.languages.Add(attr);
                    }
                }
            }

            if (course.levels != null)
            {
                foreach (SqlLevel l in course.levels)
                {
                    if (l.isdeleted == false)
                    {
                        CourseAttribute attr = new CourseAttribute();
                        attr.code = l.code;
                        attr.name = l.name;
                        attr.des = l.des;
                        item.level.Add(attr);
                    }
                }
            }

            if (course.chapters != null)
            {
                foreach (SqlChapter ch in course.chapters)
                {
                    if (ch.isdeleted == false)
                    {
                        DetailChapterDTO chapter = new DetailChapterDTO();
                        chapter.code = ch.code;
                        chapter.name = ch.name;
                        chapter.des = ch.des;
                        chapter.step = ch.step;
                        chapter.isactivated = ch.isactivated;
                        chapter.createTime = ch.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                        chapter.updateTime = ch.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");

                        if (ch.lessons != null)
                        {
                            foreach (SqlLesson ls in ch.lessons)
                            {
                                if(ls.isdeleted == false)
                                {
                                    DetailLessonDTO lesson = new DetailLessonDTO();
                                    lesson.code = ls.code;
                                    lesson.name = ls.name;
                                    lesson.des = ls.des;
                                    lesson.step = ls.step;
                                    lesson.image = ls.image;
                                    lesson.video = privateData == true ? ls.video : "";
                                    lesson.createTime = ls.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                                    lesson.updateTime = ls.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                                    chapter.lessons.Add(lesson);
                                }
                                
                            }
                        }
                        item.chapters.Add(chapter);
                    }
                }
            }

            return item;
        }

        public DataList<CourseItem> GetCreatorCourse(string creator, int page, int size, string title)
        {
            DataList<CourseItem> data = new DataList<CourseItem>();
            UserItem user = _unitOfWork.user.getUser(creator);
            if(string.IsNullOrEmpty(user.code) || string.IsNullOrEmpty(user.role) || user.role.CompareTo("creator") != 0)
            {
                return data;
            }
            IQueryable<SqlCourse> query = _unitOfWork.course.GetCondition(s => s.user != null &&
                                                                               s.user.code.CompareTo(user.code) == 0 &&
                                                                               s.isdeleted == false)
                                                            .Include(s => s.category)
                                                            .Include(s => s.languages)
                                                            .Include(s => s.levels)
                                                            .Include(s => s.user);
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(s => s.title.Contains(title));
            }
            if (page > 0 && size > 0)
            {
                data.totalPage = (int)Math.Ceiling((double)query.Count() / size);
                data.totalItem = query.Count();
                data.page = page;
                query = query.Skip(size * (page - 1))
                             .Take(size);
            }
            List<SqlCourse> courses = query.ToList();
            foreach (SqlCourse s in courses)
            {
                CourseItem item = new CourseItem();
                item.code = s.code;
                item.title = s.title;
                item.price = s.price;
                item.purchases = s.purchases;
                item.salePrice = s.salePrice;
                item.issale = s.issale;
                item.isactivated = s.isactivated;
                item.des = s.des;
                item.image = s.image;
                item.createTime = s.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                item.updateTime = s.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");

                if (s.category != null && s.category.isdeleted == false)
                {
                    item.category.code = s.category.code;
                    item.category.name = s.category.name;
                    item.category.des = s.category.des;
                }

                if (s.user != null && s.user.isdeleted == false)
                {
                    item.creator.code = s.user.code;
                    item.creator.username = s.user.username;
                    item.creator.displayName = s.user.displayName;
                    item.creator.image = s.user.image;
                }

                if (s.languages != null)
                {
                    foreach (SqlLanguage l in s.languages)
                    {
                        if (l.isdeleted == false)
                        {
                            CourseAttribute attr = new CourseAttribute();
                            attr.code = l.code;
                            attr.name = l.name;
                            attr.des = l.des;
                            item.languages.Add(attr);
                        }
                    }
                }

                if (s.levels != null)
                {
                    foreach (SqlLevel l in s.levels)
                    {
                        if (l.isdeleted == false)
                        {
                            CourseAttribute attr = new CourseAttribute();
                            attr.code = l.code;
                            attr.name = l.name;
                            attr.des = l.des;
                            item.level.Add(attr);
                        }
                    }
                }
                data.datas.Add(item);
            }
            return data;
        }

        public DataList<CourseItem> GetAllCourse(int page, int size, string title,List<string> cat, List<string> lang, List<string> lvl)
        {
            DataList<CourseItem> data = new DataList<CourseItem>();
            IQueryable<SqlCourse> query = _unitOfWork.course.GetCondition(s => s.isdeleted == false)
                                                            .Include(s => s.category)
                                                            .Include(s => s.languages)
                                                            .Include(s => s.levels)
                                                            .Include(s => s.user);
            if(cat.Count > 0)
            {
                query = query.Where(s => s.category != null && cat.Contains(s.category.code));
            }
            if (lang.Count > 0)
            {
                query = query.Where(s => s.languages!.Any(cl => lang.Contains(cl.code)) );
            }
            if (lvl.Count > 0)
            {
                query = query.Where(s => s.levels!.Any(cl => lvl.Contains(cl.code)) );
            }
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(s => s.title.Contains(title));
            }
            if (page > 0 && size > 0)
            {
                data.totalPage = (int)Math.Ceiling((double)query.Count() / size);
                data.totalItem = query.Count();
                data.page = page;
                query = query.Skip(size * (page - 1))
                             .Take(size);
            }
            List<SqlCourse> courses = query.ToList();
            foreach(SqlCourse s in courses)
            {
                CourseItem item = new CourseItem();
                item.code = s.code;
                item.title = s.title;
                item.price = s.price;
                item.purchases = s.purchases;
                item.salePrice = s.salePrice;
                item.issale = s.issale;
                item.isactivated = s.isactivated;
                item.des = s.des;
                item.image = s.image;
                item.createTime = s.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                item.updateTime = s.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");

                if (s.category != null && s.category.isdeleted == false)
                {
                    item.category.code = s.category.code;
                    item.category.name = s.category.name;
                    item.category.des = s.category.des;
                }

                if (s.user != null && s.user.isdeleted == false)
                {
                    item.creator.code = s.user.code;
                    item.creator.username = s.user.username;
                    item.creator.displayName = s.user.displayName;
                    item.creator.image = s.user.image;
                }

                if (s.languages != null)
                {
                    foreach(SqlLanguage l in s.languages)
                    {
                        if(l.isdeleted == false)
                        {
                            CourseAttribute attr = new CourseAttribute();
                            attr.code = l.code;
                            attr.name = l.name;
                            attr.des = l.des;
                            item.languages.Add(attr);
                        }
                    }
                }

                if (s.levels != null)
                {
                    foreach (SqlLevel l in s.levels)
                    {
                        if (l.isdeleted == false)
                        {
                            CourseAttribute attr = new CourseAttribute();
                            attr.code = l.code;
                            attr.name = l.name;
                            attr.des = l.des;
                            item.level.Add(attr);
                        }
                    }
                }
                data.datas.Add(item);
            }
            return data;
        }

        public async Task<SqlCourse> createCourse(string user, string title, string des, double price, double salePrice, bool issale, string category, List<string> lang, List<string> lvl)
        {
            SqlUser? creator = _unitOfWork.user.GetCode(user, 0).FirstOrDefault();
            if (creator == null)
            {
                return new SqlCourse();
            }
            List<SqlLanguage> m_languages = _unitOfWork.language.GetCondition(s => s.isdeleted == false && lang.Contains(s.code)).ToList();
            if(m_languages.Count < 0)
            {
                return new SqlCourse();
            }
            List<SqlLevel> m_levels = _unitOfWork.level.GetCondition(s => s.isdeleted == false && lvl.Contains(s.code)).ToList();
            if (m_levels.Count < 0)
            {
                return new SqlCourse();
            }
            SqlCategory? m_category = _unitOfWork.category.GetCode(category, 0).FirstOrDefault();
            if(m_category == null)
            {
                return new SqlCourse();
            }
            SqlCourse course = new SqlCourse();
            course.id = DateTime.Now.Ticks;
            course.code = ConvertString.getSlug(title);
            course.des = des;
            course.price = price;
            course.salePrice = salePrice;
            course.issale = issale;
            course.isactivated = true;
            course.isdeleted = false;
            course.category = m_category;
            course.languages = new List<SqlLanguage>();
            course.languages.AddRange(m_languages);
            course.levels = new List<SqlLevel>();
            course.levels.AddRange(m_levels);
            _unitOfWork.course.Insert(course);
            int row = await _unitOfWork.CompleteAsync();
            return row > 0 ? course : new SqlCourse();
        }

        public async Task<bool> deleteCourse(string code)
        {
            SqlCourse? course = _unitOfWork.course.GetCode(code, 0).FirstOrDefault();
            if(course == null)
            {
                return false;
            }
            course.isdeleted = true;
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<SqlCourse> updateCourse(string code,string title, string des, double price, double salePrice, bool issale, string category, List<string> languages, List<string> levels)
        {
            SqlCourse? course = _unitOfWork.course.GetCode(code, 0)
                                                  .Include(s => s.category)
                                                  .Include(s => s.languages)
                                                  .Include(s => s.levels)
                                                  .FirstOrDefault();
            if (course == null)
            {
                return new SqlCourse();
            }
            SqlCategory? m_category = _unitOfWork.category.GetCode(code, 0).FirstOrDefault();
            if (m_category == null)
            {
                return new SqlCourse();
            }

            course.title = title;
            course.des = des;
            course.price = price;
            course.salePrice = salePrice;
            course.issale = issale;
            course.category = m_category;

            List<SqlLanguage> m_languages = _unitOfWork.language.GetContains(languages).ToList();
            List<SqlLevel> m_levels = _unitOfWork.level.GetContains(levels).ToList();

            course.languages!.Clear();
            if(m_languages.Count > 0)
            {
                course.languages!.AddRange(m_languages);
            }

            course.levels!.Clear();
            if (course.levels!.Count > 0)
            {
                course.levels.AddRange(m_levels);
            }

            return await _unitOfWork.CompleteAsync() > 0 ? course : new SqlCourse();
        }

        public CourseLearningInfo getLearningCourseInfo(string code,string? user = "")
        {
            SqlCourse? course = _unitOfWork.course.GetCode(code,0)
                                                  .Include(s => s.user!)
                                                  .Include(s => s.chapters!).ThenInclude(s => s.lessons!)
                                                  .FirstOrDefault();
            if(course == null)
            {
                return new CourseLearningInfo();
            }

            CourseLearningInfo info = new CourseLearningInfo();
            info.code = course.code;
            info.title = course.title;
            info.des = course.des;
            info.image = course.image;
            
            if(course.user != null)
            {
                info.creator.code = course.user.code;
                info.creator.username = course.user.username;
                info.creator.displayName = course.user.displayName;
                info.creator.image = course.user.image;

                if(!string.IsNullOrEmpty(user) && course.user.code.CompareTo(user) == 0)
                {
                    info.isOwner = true;
                }
            }

            foreach(SqlChapter ch in course.chapters!)
            {
                if(ch.isdeleted == false)
                {
                    DetailChapterDTO chapter = new DetailChapterDTO();
                    chapter.code = ch.code;
                    chapter.name = ch.name;
                    chapter.des = ch.des;
                    chapter.step = ch.step;
                    chapter.isactivated = ch.isactivated;

                    foreach(SqlLesson ls in ch.lessons!)
                    {
                        if(ls.isdeleted == false)
                        {
                            DetailLessonDTO lesson = new DetailLessonDTO();
                            lesson.code = ls.code;
                            lesson.name = ls.name;
                            lesson.des = ls.des;
                            lesson.step = ls.step;
                            lesson.image = ls.image;
                            lesson.video = ls.video;

                            chapter.lessons.Add(lesson);
                            info.totalLesson = info.totalLesson + 1;
                        }
                    }

                    chapter.lessons = chapter.lessons.OrderBy(s => s.step).ToList();
                    info.totalChapter = info.totalChapter + 1;
                    info.chapters.Add(chapter);
                }
            }
            info.chapters = info.chapters.OrderBy(s => s.step).ToList();

            return info;
        }

        public List<CourseItem> GetUserInventory(string code, SortDateEnum sort)
        {
            List<CourseItem> datas = new List<CourseItem>();
            UserItem user = _unitOfWork.user.getUser(code);
            if(string.IsNullOrEmpty(user.code))
            {
                return new List<CourseItem>();
            }
            List<string> productCodes = GetListProductCodeBoughtByUser(code);

            if (productCodes.Count == 0)
            {
                return new List<CourseItem>();
            }

            List<SqlCourse> courses = _unitOfWork.course.GetContains(productCodes)
                                                        .Include(s => s.user)
                                                        .Include(s => s.languages)
                                                        .Include(s => s.category)
                                                        .Include(s => s.levels)
                                                        .ToList();

            foreach(SqlCourse s in courses)
            {
                if(s.isdeleted == false)
                {
                    CourseItem item = new CourseItem();
                    item.code = s.code;
                    item.title = s.title;
                    item.purchases = s.purchases;
                    item.price = s.price;
                    item.salePrice = s.salePrice;
                    item.des = s.des;
                    item.image = s.image;
                    item.isactivated = s.isactivated;
                    item.issale = s.issale;
                    item.createTime = s.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");
                    item.updateTime = s.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss");

                    if(s.user != null && s.user.isdeleted == false) {
                        item.creator = new CourseCreatorAttribute
                        {
                            code = s.user.code,
                            displayName = s.user.displayName,
                            image = s.user.image,
                            username = s.user.username
                        };
                    }

                    if (s.category != null && s.category.isdeleted == false)
                    {
                        item.category = new CourseAttribute
                        {
                            code = s.category.code,
                            name = s.category.name,
                            des = s.category.des,
                        };
                    }

                    foreach(SqlLanguage lang in s.languages)
                    {
                        if(lang.isdeleted == false)
                        {
                            CourseAttribute attr = new CourseAttribute
                            {
                                code = lang.code,
                                name = lang.name,
                                des = lang.des
                            };
                            item.languages.Add(attr);
                        }
                    }

                    foreach (SqlLevel lvl in s.levels)
                    {
                        if (lvl.isdeleted == false)
                        {
                            CourseAttribute attr = new CourseAttribute
                            {
                                code = lvl.code,
                                name = lvl.name,
                                des = lvl.des
                            };
                            item.level.Add(attr);
                        }
                    }

                    datas.Add(item);
                }
            }

            return datas;
        }

        public List<string> GetListProductCodeBoughtByUser(string user)
        {
            List<string> productCodes = _unitOfWork.order.GetAll()
                                                        .Where(order => order.user != null && order.user.code == user)
                                                        .SelectMany(order => order.details!.Where(detail => detail.course != null))
                                                        .Select(detail => detail.course!.code)
                                                        .Distinct()
                                                        .ToList();
            return productCodes;
        }
    }
}
