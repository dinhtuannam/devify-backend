using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetLearningInfoQuery : IRequest<ApiResponse>
    {
        public string course { get; set; } = "";
        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public GetLearningInfoQuery(string course, string user, string role)
        {
            this.course = course;
            this.user = user;
            this.role = role;
        }

        public class Handler : IRequestHandler<GetLearningInfoQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetLearningInfoQuery query, CancellationToken cancellationToken)
            {
                CourseLearningInfo info = new CourseLearningInfo();
                
                bool isCustomer = query.role.Equals("customer");
                bool isCreator = query.role.Equals("creator");

                SqlCourse m_course = _unitOfWork.course.GetRawEntityByCode(query.course);
                if(m_course == null)
                {
                    return Task.FromResult(new ApiResponse(false, "Không tìm thấy dữ liệu", info, 404));
                }

                info = _unitOfWork.course.getLearningCourseInfo(query.course, query.user);
                if (isCustomer || (isCreator && query.user.CompareTo(info.creator.code) != 0))
                {
                    List<string> codes = _unitOfWork.course.GetListProductCodeBoughtByUser(query.user);
                    string? bought = codes.Where(s => s.CompareTo(info.code) == 0).FirstOrDefault();
                    if (bought == null)
                    {
                        return Task.FromResult(new ApiResponse(false, "Bạn không có quyền truy cập", info, 403));
                    }
                }

                if (string.IsNullOrEmpty(info.code))
                {
                    return Task.FromResult(new ApiResponse(false, "Không tìm thấy dữ liệu", info, 404));
                }
                return Task.FromResult(new ApiResponse(true, "Lấy dữ liệu khóa học thành công", info, 200));
            }
        }
    }
}
