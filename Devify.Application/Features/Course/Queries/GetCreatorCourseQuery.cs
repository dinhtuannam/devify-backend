using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.Course.Queries
{
    public class GetCreatorCourseQuery : IRequest<ApiResponse>
    {
        public string creator { get; set; } = "";
        public int page { get; set; } = 0;
        public int size { get; set; } = 0;
        public string title { get; set; } = "";
        public GetCreatorCourseQuery(string creator,int page,int size,string title)
        {
            this.creator = creator;
            this.page = page;
            this.size = size;
            this.title = title;
        }
        public class Handler : IRequestHandler<GetCreatorCourseQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetCreatorCourseQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get creator course successfully",
                    code = 200,
                    data = _unitOfWork.course.GetCreatorCourse(query.creator,query.page,query.size,query.title)
                };
                return Task.FromResult(res);
            }
        }
    }
}
