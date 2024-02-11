using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.User.Queries
{
    public class GetProfileQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public GetProfileQuery(string code)
        {
            this.code = code;
        }
        public class Handler : IRequestHandler<GetProfileQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetProfileQuery query, CancellationToken cancellationToken)
            {
                UserProfile profile = new UserProfile();
                UserItem user = _unitOfWork.user.getUser(query.code);
                if (string.IsNullOrEmpty(user.code))
                {
                    return Task.FromResult(new ApiResponse(false, "user not found", profile, 404));
                }
                profile.information = user;
                if(user.role.CompareTo("creator") == 0 || user.role.CompareTo("admin") == 0)
                {
                    DataList<CourseItem> temp = _unitOfWork.course.GetCreatorCourse(query.code, 0, 0, "");
                    profile.courses = temp.datas;
                }

                return Task.FromResult(new ApiResponse(true, "get profile user successfully", profile, 200));
            }
        }
    }
}
