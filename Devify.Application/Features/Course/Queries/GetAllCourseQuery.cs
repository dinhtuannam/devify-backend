using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetAllCourseQuery : IRequest<ApiResponse>
    {
        private int page { get; set; } = 0;
        private int size { get; set; } = 0;
        private string title { get; set; } = "";
        private List<string> cat { get; set; } = new List<string>();
        private List<string> lang { get; set; } = new List<string>();
        private List<string> lvl { get; set; } = new List<string>();
        public GetAllCourseQuery(string title,int size,int page, List<string> cat, List<string> lang, List<string> lvl)
        {
            this.title = title;
            this.size = size;
            this.page = page;
            this.cat = cat;
            this.lang = lang;
            this.lvl = lvl;
        }
        public class Handler : IRequestHandler<GetAllCourseQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetAllCourseQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get all course successfully",
                    code = 200,
                    data = _unitOfWork.course.GetAllCourse(query.page,query.size,query.title,query.cat,query.lang,query.lvl)
                };
                return Task.FromResult(res);
            }
        }
    }
}
