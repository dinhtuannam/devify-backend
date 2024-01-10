using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Commands
{
    public class UpdateCourseChapterCommand : IRequest<ApiResponse>
    {
        public UpdateCourseChapterRequest UpdateCourseChapterRequest { get; set; }
        public Guid CourseId { get; set; }

        public class UpdateCourseChapterCommandHandler : IRequestHandler<UpdateCourseChapterCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateCourseChapterCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(UpdateCourseChapterCommand command, CancellationToken cancellationToken)
            {
                var apiResponse = new ApiResponse
                {
                    result = true,
                    message = "create course successfully",
                };
                /*UpdateCourseChapterRequest req = command.UpdateCourseChapterRequest;
                Guid CourseIdReq = command.CourseId;
                SqlChapter curChapter = _unitOfWork.ChapterRepository
                                                .GetByCondition(c => c.ChapterId == req.ChapterId && c.CourseId == CourseIdReq &&  c.Status != Entity.Enums.CommonEnum.DELETED )
                                                .FirstOrDefault();
                if(curChapter == null)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "failed";
                    apiResponse.ErrCode = "400";
                    return apiResponse;
                }
                if(curChapter.Step == req.Step)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "failed";
                    apiResponse.ErrCode = "400";
                    return apiResponse;
                }

                curChapter.Name = req.Name;
                curChapter.Description = req.Description;
                curChapter.Step = req.Step;
                curChapter.Status = req.Status;
                curChapter.DateUpdated = DateTime.Now;
                var update = _unitOfWork.ChapterRepository.UpdateEntity(curChapter);
                await _unitOfWork.CompleteAsync();*/
                return apiResponse;
            }
        }
    }
}
