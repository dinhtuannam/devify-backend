using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;

namespace Devify.Application.Features.Course.Commands
{
    public class UpdateChapterCommand : IRequest<ApiResponse>
    {
        public UpdateChapterCommand(string user, string role, string code,string name, string des, int step)
        {
            this.user = user;
            this.role = role;
            this.code = code;
            this.name = name;
            this.des = des;
            this.step = step;
        }

        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public int step { get; set; } = 0;

        public class Handler : IRequestHandler<UpdateChapterCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(UpdateChapterCommand query, CancellationToken cancellationToken)
            {
                DetailChapterDTO chapter = new DetailChapterDTO();
                if (string.IsNullOrEmpty(query.user) || string.IsNullOrEmpty(query.role))
                {
                    return new ApiResponse(false, "Bạn không có quyền thao tác", chapter, 401);
                }
                if (query.role.CompareTo("customer") == 0)
                {
                    return new ApiResponse(false, "Bạn không có quyền thao tác", chapter, 403);
                }
                CourseItem course = _unitOfWork.course.GetCourseByLesson(query.code);
                if (query.role.CompareTo("creator") == 0 || query.role.CompareTo("manager") == 0)
                {
                    if (course.creator == null || course.creator.code.CompareTo(query.user) != 0)
                    {
                        return new ApiResponse(false, "Bạn không có quyền thao tác", chapter, 403);
                    }
                }
                SqlChapter newChapter = await _unitOfWork.chapter.UpdateChapter(query.code, query.name, query.des, query.step);
                if (string.IsNullOrEmpty(newChapter.code))
                {
                    return new ApiResponse(false, "Có lỗi xày ra vui lòng thử lại", chapter, 400);
                }
                chapter = _unitOfWork.chapter.GetDetailChapter(newChapter.code);
                return new ApiResponse(false, "Cập nhật chương học thành công", chapter, 200);

            }
        }
    }
}
