using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Course.Commands
{
    public class CreateCourseCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string title { get; set; } = "";
        public string des { get; set; } = "";
        public double price { get; set; } = 0;
        public double salePrice { get; set; } = 0;
        public bool issale { get; set; } = false;
        public string category { get; set; } = "";
        public List<string> lang { get; set; } = new List<string>();
        public List<string> lvl { get; set; } = new List<string>();
        public CreateCourseCommand(string user, string title, string des, double price, double salePrice, bool issale, string category,List<string> lang,List<string> lvl)
        {
            this.user = user;
            this.title = title;
            this.des = des;
            this.price = price;
            this.salePrice = salePrice;
            this.issale = issale;
            this.category = category;
            this.lang = lang;
            this.lvl = lvl;
        }

        public class Handler : IRequestHandler<CreateCourseCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(CreateCourseCommand query, CancellationToken cancellationToken)
            {
                SqlCourse? course = await _unitOfWork.course.createCourse(
                    query.user,
                    query.title,
                    query.des,
                    query.price,
                    query.salePrice,
                    query.issale,
                    query.category,
                    query.lang,
                    query.lvl
                );
                if (string.IsNullOrEmpty(course.code))
                {
                    return new ApiResponse(false, "Create course failed", "", 400);
                }

                await Task.WhenAll(
                    _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.course),
                    _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.creatorCourse(query.user))
                );
                
                return new ApiResponse(true, "Create course successfully", course.code, 200);
            }
        }
    }
}
