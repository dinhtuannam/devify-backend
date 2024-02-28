using Devify.Application.DTO;
using Devify.Entity;
using Devify.Entity.Enums;


namespace Devify.Application.Interfaces
{
    public interface IFirebaseRepository : IGenericRepository<SqlFile>
    {
        Task<string> UploadImage(Stream stream, string fileName);
        Task<string> UploadVideo(Stream stream, string fileName);
        Task<bool> Delete(string path,FileEnum type);
    }
}
