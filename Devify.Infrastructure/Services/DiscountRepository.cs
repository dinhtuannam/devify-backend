using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;


namespace Devify.Infrastructure.Services
{
    public class DiscountRepository : GenericRepository<SqlDiscount>, IDiscountRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public DiscountRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
