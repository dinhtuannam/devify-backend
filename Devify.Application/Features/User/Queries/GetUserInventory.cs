using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity.Enums;
using MediatR;


namespace Devify.Application.Features.User.Queries
{
    public class GetUserInventory : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public GetUserInventory(string code) { this.code = code; }
        public class Handler : IRequestHandler<GetUserInventory, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetUserInventory query, CancellationToken cancellationToken)
            {
                List<CourseItem> datas = _unitOfWork.course.GetUserInventory(query.code,SortDateEnum.CreateDateDesc);
                return Task.FromResult(new ApiResponse(true, "Get user's inventory successfully", datas, 200));
            }
        }
    }
}
