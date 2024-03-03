using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Commands
{
    public class DeleteLessonCommand : IRequest<ApiResponse>
    {
        public DeleteLessonCommand(string user, string role, string code)
        {
            this.user = user;
            this.role = role;
            this.code = code;

        }
        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public string code { get; set; } = "";

        public class Handler : IRequestHandler<DeleteLessonCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(DeleteLessonCommand query, CancellationToken cancellationToken)
            {
                bool result = false;
                if (string.IsNullOrEmpty(query.user) || string.IsNullOrEmpty(query.role))
                {
                    return new ApiResponse(false, "Bạn không có quyền thao tác", result, 401);
                }
                if (query.role.CompareTo("customer") == 0)
                {
                    return new ApiResponse(false, "Bạn không có quyền thao tác", result, 403);
                }
                CourseItem course = _unitOfWork.course.GetCourseByLesson(query.code);
                if (query.role.CompareTo("creator") == 0 || query.role.CompareTo("manager") == 0)
                {
                    if (course.creator == null || course.creator.code.CompareTo(query.user) != 0)
                    {
                        return new ApiResponse(false, "Bạn không có quyền thao tác", result, 403);
                    }
                }
                result = await _unitOfWork.lesson.deleteLesson(query.code);
                if (!result)
                {
                    return new ApiResponse(false, "Có lỗi xày ra vui lòng thử lại", result, 400);
                }
                return new ApiResponse(false, "Cập nhật chương học thành công", result, 200);

            }
        }
    }
}
