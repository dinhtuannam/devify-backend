using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Commands
{
    public class CreateCourseCommand : IRequest<ApiResponse>
    {
        public CreateCourseRequest request { get; set; }
        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand,ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateCourseCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
            {                
                var apiResponse = new ApiResponse
                {
                    Success = true,
                    Message = "create course successfully", 
                };
                /*var createCourseResult = false;
                var firebaseResult = new FirebaseDTO();
                var isSlugValid = _unitOfWork.CourseRepository.GetByCondition(c => c.Slug == command.request.Slug).ToList();
                if (isSlugValid.Count > 0)
                {
                    var newSlug = command.request.Slug;
                    newSlug = AutoGenerate.GenerateRandomString(newSlug, 5);
                    command.request.Slug = newSlug;
                }
                var newCourse = new Entity.SqlCourse
                {
                    CourseId = new Guid(),
                    Title = command.request.Title,
                    Purchased = command.request.Purchased,
                    Price = command.request.Price,
                    Description = command.request.Description,
                    Slug = command.request.Slug,
                    Image = "",
                    Status = "active",
                    CreatorId = command.request.CreatorId,
                    CategoryId = command.request.CategoryId,
                    CourseLevelId = command.request.CourseLevelId,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,

                };             
                if (command.request.Image.Length > 0)
                {
                    var fileName = DateTime.UtcNow.ToString("yymmssfff") + command.request.Image.FileName;
                    firebaseResult = await _unitOfWork.FirebaseRepository.UploadToFirebase(command.request.Image.OpenReadStream(), fileName);
                }
                if (firebaseResult.Success == true)
                {
                    newCourse.Image = firebaseResult.Data;
                    createCourseResult = await _unitOfWork.CourseRepository.AddAsAsync(newCourse);
                }
                if (createCourseResult == false)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "create course failed";
                }
                await _unitOfWork.CompleteAsync();*/
                return apiResponse;
            }
        }
    }
}
