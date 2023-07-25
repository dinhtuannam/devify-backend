using Devify.Application.DTO;


namespace Devify.Application.Interfaces
{
    public interface IFirebaseRepository
    {
        Task<FirebaseDTO> UploadToFirebase(Stream stream, string fileName);
    }
}
