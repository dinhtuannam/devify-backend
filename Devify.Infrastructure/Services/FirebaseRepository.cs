using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Entity.Enums;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Firebase.Auth;
using Firebase.Storage;


namespace Devify.Infrastructure.Services
{
    public class FirebaseRepository : GenericRepository<SqlFile>, IFirebaseRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public FirebaseRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }
        private static string ApiKey = "AIzaSyB62sjMMpqGjS6noAKPDGfHIJX3WvtBi9c";
        private static string Bucket = "devify-storage.appspot.com";
        private static string AuthEmail = "admin26@gmail.com";
        private static string AuthPassword = "admin26";

        public async Task<string> UploadImage(Stream stream, string fileName)
        {
            try
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
                    .Child(fileName)
                    .PutAsync(stream, cancellation.Token);

                string firebaseUrl = await firebaseTask;
                if (!string.IsNullOrEmpty(firebaseUrl))
                {
                    SqlFile file = new SqlFile()
                    {
                        id = DateTime.Now.Ticks,
                        fileName = fileName,
                        path = firebaseUrl,
                        type = Entity.Enums.FileEnum.Image,
                        time = DateTime.Now
                    };
                    _unitOfWork.file.Insert(file);
                    await _unitOfWork.CompleteAsync();
                }
                
                return firebaseUrl;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<string> UploadVideo(Stream stream, string fileName)
        {
            try
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
                    .Child("videos")
                    .Child("lessons")
                    .Child(fileName)
                    .PutAsync(stream, cancellation.Token);
                string firebaseUrl = await firebaseTask;
                if (!string.IsNullOrEmpty(firebaseUrl))
                {
                    SqlFile file = new SqlFile()
                    {
                        id = DateTime.Now.Ticks,
                        fileName = fileName,
                        path = firebaseUrl,
                        type = Entity.Enums.FileEnum.Video,
                        time = DateTime.Now
                    };
                    _unitOfWork.file.Insert(file);
                    await _unitOfWork.CompleteAsync();
                }
                return firebaseUrl;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<bool> Delete(string path,FileEnum type)
        {
            try
            {
                SqlFile? file = _unitOfWork.file.GetCondition(s => s.path.CompareTo(path) == 0).FirstOrDefault();
                if (file == null)
                {
                    return false;
                }
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var signInResult = await authProvider.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                var firebaseStorage = new FirebaseStorage(
                    Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(signInResult.FirebaseToken),
                        ThrowOnCancel = true
                    }
                );
                if(type == FileEnum.Image)
                {
                    await firebaseStorage
                    .Child("images")
                    .Child(file.fileName)
                    .DeleteAsync();
                }
                else
                {
                    await firebaseStorage
                    .Child("videos")
                    .Child("lessons")
                    .Child(file.fileName)
                    .DeleteAsync();
                }

                _unitOfWork.file.Delete(file);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
