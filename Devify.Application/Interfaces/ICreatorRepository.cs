using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ICreatorRepository : IGenericRepository<Creator>
    {
        Task<DetailCreatorDTO> GetDetailCreator(string id);
        Task<DetailCreatorPublicDTO> GetCreatorBySlug(string slug);
    }
}
