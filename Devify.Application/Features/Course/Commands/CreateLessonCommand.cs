using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;


namespace Devify.Application.Features.Course.Commands
{
    public class CreateLessonCommand : IRequest<ApiResponse>
    {
        public CreateLessonCommand(string user, string role, string chapter, string name, string des, int step)
        {
            this.user = user;
            this.role = role;
            this.chapter = chapter;
            this.name = name;
            this.des = des;
            this.step = step;
        }

        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public string chapter { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public int step { get; set; } = 0;

        public class Handler : IRequestHandler<CreateLessonCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(CreateLessonCommand query, CancellationToken cancellationToken)
            {
                DetailLessonDTO lesson = new DetailLessonDTO();
                if (string.IsNullOrEmpty(query.user) || string.IsNullOrEmpty(query.role))
                {
                    return new ApiResponse(false, "Bạn không có quyền thao tác", lesson, 401);
                }
                if (query.role.CompareTo("customer") == 0)
                {
                    return new ApiResponse(false, "Bạn không có quyền thao tác", lesson, 403);
                }
                CourseItem course = _unitOfWork.course.GetCourseByChapter(query.chapter);
                if (string.IsNullOrEmpty(course.code))
                {
                    return new ApiResponse(false, "Không tìm thấy khóa học", lesson, 404);
                }
                if (query.role.CompareTo("creator") == 0 || query.role.CompareTo("manager") == 0)
                {
                    if (course.creator == null || course.creator.code.CompareTo(query.user) != 0)
                    {
                        return new ApiResponse(false, "Bạn không có quyền thao tác", lesson, 403);
                    }
                }
                SqlLesson newLesson = await _unitOfWork.lesson.createLesson(query.chapter, query.name, query.des, query.step);
                if (string.IsNullOrEmpty(newLesson.code))
                {
                    return new ApiResponse(false, "Có lỗi xày ra vui lòng thử lại", lesson, 400);
                }
                lesson = _unitOfWork.lesson.getDetailLesson(lesson.code);
                return new ApiResponse(false, "Tạo bài học thành công", lesson, 200);

            }
        }
    }
}
