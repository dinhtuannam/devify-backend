using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Firebase.Auth;
using Firebase.Storage;
using System.Net.Sockets;

namespace Devify.Infrastructure.Services
{
    public class FirebaseRepository : IFirebaseRepository
    {
        private static string ApiKey = "AIzaSyB62sjMMpqGjS6noAKPDGfHIJX3WvtBi9c";
        private static string Bucket = "devify-storage.appspot.com";
        private static string AuthEmail = "admin26@gmail.com";
        private static string AuthPassword = "admin26";
        public FirebaseRepository() { }
        public FirebaseDTO test()
        {
            return new FirebaseDTO
            {
                Success = true,
                Message = "abc",
                Data = "abc"
            };
        }
        public async Task<FirebaseDTO> UploadToFirebase(Stream stream, string fileName)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var signInResult = await authProvider.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
            var cancellation = new CancellationTokenSource();

            var firebaseTask = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(signInResult.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child("images")
                .Child("courses")
                .Child(fileName)
                .PutAsync(stream, cancellation.Token);
            try
            {
                string firebaseUrl = await firebaseTask;
                Console.WriteLine($"[FirebaseService] -> UploadToFirebase width fileName: {fileName} -> successfully");
                return new FirebaseDTO
                {
                    Success = true,
                    Message = "Upload file to firebase successfully",
                    Data = firebaseUrl
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FirebaseService] -> UploadToFirebase width fileName: {fileName} -> failed -> Exception : {ex}");
                return new FirebaseDTO
                {
                    Success = false,
                    Message = $"Upload file to firebase failed",
                };
                
            }
        }
    }
}
