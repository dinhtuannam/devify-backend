using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Infrastructure.Services
{
    public class OrderRepository : GenericRepository<SqlOrder>, IOrderRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }
    }
}
