﻿using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Creator.Queries
{
    public class GetCreatorByConditionQuery : IRequest<ApiResponse>
    {
        public string condition { get; set; }
        //public ConditionEnum type { get; set; }

        public class GetCreatorByConditionQueryHandler : IRequestHandler<GetCreatorByConditionQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetCreatorByConditionQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(GetCreatorByConditionQuery query, CancellationToken cancellationToken)
            {
                ApiResponse response = new ApiResponse
                {
                    result = true,
                    message = "Get creator info successfully",
                    code = 200
                };
               /* if(query.type == ConditionEnum.SLUG)
                {
                    DetailCreatorPublicDTO result = new DetailCreatorPublicDTO();
                    result = await _unitOfWork.CreatorRepository.GetCreatorBySlug(query.condition);
                    if(result != null)
                    {
                        response.Data = result;
                        return response;
                    }
                    response.ErrCode = "404";
                    response.Success = false;
                    response.Message = "Get creator info failed";
                    return response;
                }          
                if (query.type == ConditionEnum.ID)
                {
                    DetailCreatorDTO result = new DetailCreatorDTO();
                    result = await _unitOfWork.CreatorRepository.GetDetailCreator(query.condition);
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
                    result = false,
                    message = "Something wrong",
                    code = 500
                };
            }
        }

    }
}
