using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Entity.Enums;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class LevelRepository : GenericRepository<CourseLevel>, ILevelRepository
    {
        public LevelRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
        }

        public override async Task<IEnumerable<CourseLevel>> GetAllAsync()
        {
            try
            {
                var model = await _dbSet.Where(c => c.Status == CommonEnum.AVAILABLE)
                .Select(c => new CourseLevel
                {
                    CourseLevelId = c.CourseLevelId,
                    LevelName = c.LevelName,
                    LevelDescription = c.LevelDescription,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateUpdated
                }).ToListAsync();
                return model;
            }
            catch (Exception ex)
            {
                return new List<CourseLevel>();
            }
        }
    }
}
