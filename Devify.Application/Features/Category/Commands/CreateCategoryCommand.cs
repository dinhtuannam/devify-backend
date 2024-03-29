﻿using Devify.Application.Commons;
using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;

namespace Devify.Application.Features.Category.Commands
{
    public class CreateCategoryCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";

        public CreateCategoryCommand(string code, string name, string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }

        public class Handler : IRequestHandler<CreateCategoryCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(CreateCategoryCommand query, CancellationToken cancellationToken)
            {
                CategoryItem exist = _unitOfWork.category.getCategory(query.code);
                if (!string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "Thể loại đã tồn tại", "", 400);
                }
                SqlCategory cat = await _unitOfWork.category.createCategory(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(cat.code))
                {
                    return new ApiResponse(false, "Tạo thể loại thất bại","",400);
                }
                await _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.category);
                return new ApiResponse(true, "Tạo thể loại thành công", cat.code, 200);
            }
        }
    }
}
