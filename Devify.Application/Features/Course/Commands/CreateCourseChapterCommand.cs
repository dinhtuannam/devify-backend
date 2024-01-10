using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.Course.Commands
{
    public class CreateCourseChapterCommand : IRequest<ApiResponse>
    {
        public CreateCourseChapterRequest request { get; set; }
        public Guid CourseId { get; set; }
        public class CreateCourseChapterCommandHandler : IRequestHandler<CreateCourseChapterCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateCourseChapterCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(CreateCourseChapterCommand command, CancellationToken cancellationToken)
            {
                var apiResponse = new ApiResponse
                {
                    result = true,
                    message = "create course successfully",
                    code = 200
                };
                /*CreateCourseChapterRequest req = command.request;
                Guid courseRequestId = command.CourseId;
                Entity.SqlCourse course = _unitOfWork.CourseRepository.GetMulti(c => c.CourseId == courseRequestId && c.Status != "deleted", new string[] {"Chapters"}).FirstOrDefault();
                if(course == null)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "failed";
                    apiResponse.ErrCode = "400";
                    return apiResponse;
                }
                SqlChapter curStep = course.Chapters.Where(c => c.Step == req.Step).FirstOrDefault();
                if (curStep != null)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "failed";
                    apiResponse.ErrCode = "400";
                    return apiResponse;
                }
                SqlChapter newChapter = new SqlChapter
                {
                    ChapterId = new Guid(),
                    Name = req.Name,
                    Step = req.Step,
                    Description = req.Description,
                    CourseId = courseRequestId,
                    Status = Entity.Enums.CommonEnum.AVAILABLE,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };
                await _unitOfWork.ChapterRepository.AddAsAsync(newChapter);
                await _unitOfWork.CompleteAsync();*/
                return apiResponse;
            }
        }
    }
}
