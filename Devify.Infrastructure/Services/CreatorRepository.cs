using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class CreatorRepository : GenericRepository<Creator>, ICreatorRepository 
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IUnitOfWork _unitOfWork;
        public CreatorRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _DbContext = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<DetailCreatorPublicDTO> GetCreatorBySlug(string slug)
        {
            try
            {
                var query = GetMulti(c => c.Slug == slug, new string[] { "User" }).Select(cr => new DetailCreatorPublicDTO
                {
                    CreatorId = cr.CreatorId,
                    Slug = cr.Slug,
                    FacebookUrl = cr.FacebookUrl,
                    LinkedInUrl = cr.LinkedInUrl,
                    DisplayName = cr.User.DisplayName,
                    Image = cr.User.Image,
                }).FirstOrDefault(); ;
                return query;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<CreatorCoursesDTO> GetCreatorCoursesById(string id)
        {
            try
            {
                var query = _unitOfWork.CourseRepository.GetMulti(c => c.CreatorId == id)
                    .Select(course => new CreatorCoursesDTO
                    {
                        CourseId = course.CourseId,
                        Title = course.Title,
                        Image = course.Image,
                        Description = course.Description,
                        Price = course.Price,
                        Slug = course.Slug
                    }).ToList();
                return query;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<CreatorCoursesDTO>> GetCreatorCoursesBySlug(string slug)
        {
            try
            {
                var creatorFind = await GetByCondition(x => x.Slug == slug).Select(c => new Creator
                {
                    CreatorId = c.CreatorId
                }).FirstOrDefaultAsync();
                if(creatorFind == null) {
                    return null;
                }
                var query = _unitOfWork.CourseRepository.GetMulti(c => c.CreatorId == creatorFind.CreatorId)
                    .Select(course => new CreatorCoursesDTO
                    {
                        CourseId = course.CourseId,
                        Title = course.Title,
                        Image = course.Image,
                        Description = course.Description,
                        Price = course.Price,
                        Slug = course.Slug
                    }).ToList();
                return query;
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        public async Task<DetailCreatorDTO> GetDetailCreator(string id)
        {

            try
            {
                var query = await _unitOfWork.CreatorRepository.GetByCondition(condition: ls => ls.CreatorId == id)
                .Include(cr => cr.User)
                .Select(cr => new DetailCreatorDTO
                {
                    CreatorId = cr.CreatorId,
                    Slug = cr.Slug,
                    FacebookUrl = cr.FacebookUrl,
                    LinkedInUrl = cr.LinkedInUrl,
                    DisplayName = cr.User.DisplayName,
                    Image = cr.User.Image,
                    UserName = cr.User.UserName,
                    Email = cr.User.Email,
                    PhoneNumber = cr.User.PhoneNumber
                })
                .FirstOrDefaultAsync();
                return query;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
