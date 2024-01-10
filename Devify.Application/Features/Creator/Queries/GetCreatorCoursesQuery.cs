using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.Creator.Queries
{
    public class GetCreatorCoursesQuery : IRequest<ApiResponse>
    {
        public string condition { get; set; }
        //public ConditionEnum type { get; set; }

        public class GetCreatorCoursesQueryHandler : IRequestHandler<GetCreatorCoursesQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetCreatorCoursesQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(GetCreatorCoursesQuery query, CancellationToken cancellationToken)
            {
                ApiResponse response = new ApiResponse
                {
                    Success = true,
                    Message = "Get creator info successfully",
                    ErrCode = "200"
                };
                /*if (query.type == ConditionEnum.SLUG)
                {
                    IEnumerable<CreatorCoursesDTO> result = new List<CreatorCoursesDTO>();
                    result = await _unitOfWork.CreatorRepository.GetCreatorCoursesBySlug(query.condition);
                    if (result != null)
                    {
                        response.Data = result;
                        return response;
                    }
                    response.ErrCode = "404";
                    response.Success = false;
                    response.Message = "Get creator courses info failed";
                    return response;
                }
                if (query.type == ConditionEnum.ID)
                {
                    IEnumerable<CreatorCoursesDTO> result = new List<CreatorCoursesDTO>();
                    result = _unitOfWork.CreatorRepository.GetCreatorCoursesById(query.condition);
                    if (result != null)
                    {
                        response.Data = result;
                        return response;
                    }
                    response.ErrCode = "404";
                    response.Success = false;
                    response.Message = "Get creator info failed";
                    return response;
                }*/
                return new ApiResponse
                {
                    Success = false,
                    Message = "Something wrong",
                    ErrCode = "500"
                };
            }
        }
    }
}
