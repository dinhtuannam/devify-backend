using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class LevelRepository : GenericRepository<SqlLevel>, ILevelRepository
    {
        public LevelRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
        }

       
    }
}
