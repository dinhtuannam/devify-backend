using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ICreatorRepository : IGenericRepository<Creator>
    {
        Task<DetailCreatorDTO> GetDetailCreator(string id);
        Task<DetailCreatorDTO> GetCreatorBySlug(string slug);
    }
}
