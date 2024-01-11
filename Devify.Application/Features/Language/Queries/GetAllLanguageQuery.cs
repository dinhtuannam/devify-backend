﻿using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Language.Queries
{
    public class GetAllLanguageQuery : IRequest<ApiResponse>
    {
        public class Handler : IRequestHandler<GetAllLanguageQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetAllLanguageQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get list language successfully",
                    code = 0,
                    data = _unitOfWork.LanguageRepository.getAllLanguages()
                };
                return Task.FromResult(res);
            }
        }
    }
}
