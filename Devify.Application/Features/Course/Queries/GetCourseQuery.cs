using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetCourseQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public bool privateData { get; set; } = false;
        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public GetCourseQuery(string code,bool privateData,string user,string role)
        {
            this.code = code;
            this.privateData = privateData;
            this.user = user;
            this.role = role;
        }
        public class Handler : IRequestHandler<GetCourseQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetCourseQuery query, CancellationToken cancellationToken)
            {
                DetailCourseDTO course = _unitOfWork.course.GetCourse(query.code,query.privateData);
                if (!string.IsNullOrEmpty(query.user))
                {
                    if (query.role.CompareTo("creator") == 0 && course.creator.code.CompareTo(query.user) == 0)
                    {
                        course.owner = true;
                    }
                    else
                    {
                        List<string> courseCodes = _unitOfWork.course.GetListProductCodeBoughtByUser(query.user);
                        string? exist = courseCodes.Where(s => s.CompareTo(course.code) == 0).FirstOrDefault();
                        course.owner = exist != null ? true : false;
                    }
                }
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get course successfully",
                    code = 200,
                    data = course
                };
                return Task.FromResult(res);
            }
        }
    }
}
