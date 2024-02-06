using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetCourseQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public bool privateData { get; set; } = false;
        public GetCourseQuery(string code,bool privateData)
        {
            this.code = code;
            this.privateData = privateData;
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
