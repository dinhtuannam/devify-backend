using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Commands
{
    public class CreateCourseLessonCommand : IRequest<ApiResponse>
    {
        public CreateCourseLessonRequest request { get; set; }
        public Guid ChapterId { get; set; }
        public class CreateCourseLessonCommandHandler : IRequestHandler<CreateCourseLessonCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateCourseLessonCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(CreateCourseLessonCommand command, CancellationToken cancellationToken)
            {
                var apiResponse = new ApiResponse
                {
                    Success = true,
                    Message = "create course lesson successfully",
                    ErrCode = "200"
                };
                /*CreateCourseLessonRequest req = command.request;
                Guid chapterRequestId = command.ChapterId;
                Entity.SqlChapter chapter = _unitOfWork.ChapterRepository.GetMulti(c => c.ChapterId == chapterRequestId && c.Status != Entity.Enums.CommonEnum.DELETED, new string[] { "Lessons" }).FirstOrDefault();
                if (chapter == null)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "failed";
                    apiResponse.ErrCode = "400";
                    return apiResponse;
                }
                SqlLesson curStep = chapter.Lessons.Where(c => c.Step == req.Step).FirstOrDefault();
                if (curStep != null)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "failed";
                    apiResponse.ErrCode = "400";
                    return apiResponse;
                }
                SqlLesson newLesson = new SqlLesson
                {
                    LessonId = new Guid(),
                    Name = req.Name,
                    Step = req.Step,
                    Description = req.Description,
                    ChapterId = chapterRequestId,
                    Status = Entity.Enums.LessonEnum.AVAILABLE,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };
                await _unitOfWork.LessonRepository.AddAsAsync(newLesson);
                await _unitOfWork.CompleteAsync();*/
                return apiResponse;
            }
        }
    }
}
