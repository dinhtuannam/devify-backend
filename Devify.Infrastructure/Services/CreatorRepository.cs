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
