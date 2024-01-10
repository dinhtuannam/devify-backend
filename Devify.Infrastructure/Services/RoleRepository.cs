using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;

namespace Devify.Infrastructure.Services
{
    public class RoleRepository : GenericRepository<SqlRole>, IRoleRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
