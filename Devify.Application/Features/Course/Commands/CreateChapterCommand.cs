using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;


namespace Devify.Application.Features.Course.Commands
{
    public class CreateChapterCommand : IRequest<ApiResponse>
    {
        public CreateChapterCommand(string user, string role, string course, string name, string des, int step)
        {
            this.user = user;
            this.role = role;
            this.course = course;
            this.name = name;
            this.des = des;
            this.step = step;
        }

        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public string course { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public int step { get; set; } = 0;

        public class Handler : IRequestHandler<CreateChapterCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(CreateChapterCommand query, CancellationToken cancellationToken)
            {
                DetailChapterDTO chapter = new DetailChapterDTO();
                if(string.IsNullOrEmpty(query.user) || string.IsNullOrEmpty(query.role))
                {
                    return new ApiResponse(false, "Bạn không có quyền thao tác", chapter, 401);
                }
                if(query.role.CompareTo("customer") == 0)
                {
                    return new ApiResponse(false, "Bạn không có quyền thao tác", chapter, 403);
                }
                DetailCourseDTO course = _unitOfWork.course.GetCourse(query.course, false);
                if (string.IsNullOrEmpty(query.course))
                {
                    return new ApiResponse(false, "Không tìm thấy khóa học", chapter, 404);
                }
                if (query.role.CompareTo("creator") == 0 || query.role.CompareTo("manager") == 0)
                {
                    if(course.creator == null || course.creator.code.CompareTo(query.user) != 0)
                    {
                        return new ApiResponse(false, "Bạn không có quyền thao tác", chapter, 403);
                    }
                }
                SqlChapter newChapter = await _unitOfWork.chapter.CreateChapter(query.course, query.name, query.des, query.step);
                if (string.IsNullOrEmpty(newChapter.code))
                {
                    return new ApiResponse(false, "Có lỗi xày ra vui lòng thử lại", chapter, 400);
                }
                chapter = _unitOfWork.chapter.GetDetailChapter(newChapter.code);
                return new ApiResponse(false, "Tạo chương học thành công", chapter, 200);

            }
        }
    }
}
