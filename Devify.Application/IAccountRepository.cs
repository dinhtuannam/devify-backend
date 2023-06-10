using Devify.Entity;

namespace Devify.Application
{
    public interface IAccountRepository
    {
        Account GetById(int id);
        
    }
}
