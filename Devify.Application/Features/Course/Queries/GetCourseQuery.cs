using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetCourseQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public GetCourseQuery(string code)
        {
            this.code = code;
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
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get course successfully",
                    code = 200,
                    data = _unitOfWork.course.GetCourse(query.code)
                };
                return Task.FromResult(res);
            }
        }
    }
}
