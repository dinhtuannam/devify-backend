using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Course.Commands
{
    public class DeleteCourseCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public string code { get; set; } = "";

        public DeleteCourseCommand(string code,string user,string role)
        {
            this.code = code;
            this.user = user;
            this.role = role;
        }

        public class Handler : IRequestHandler<DeleteCourseCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(DeleteCourseCommand query, CancellationToken cancellationToken)
            {
                if(string.IsNullOrEmpty(query.user) || string.IsNullOrEmpty(query.role))
                {
                    return new ApiResponse(false, "Bạn không có quyền truy cập", false, 403);
                }
                DetailCourseDTO course = _unitOfWork.course.GetCourse(query.code);
                if (string.IsNullOrEmpty(course.code) || string.IsNullOrEmpty(course.creator.code))
                {
                    return new ApiResponse(false, "Không tìm thấy khóa học", false, 404);
                }
                if(query.role.CompareTo("creator") == 0 && course.creator.code.CompareTo(query.user) != 0)
                {
                    return new ApiResponse(false, "Bạn không có quyền truy cập", false, 403);
                }
                bool result = await _unitOfWork.course.deleteCourse(query.code);
                if (!result)
                {
                    return new ApiResponse(false, "Xóa khóa học thất bại", false, 400);
                }

                await Task.WhenAll(
                    _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.course),
                    _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.creatorCourse(query.user))
                );

                return new ApiResponse(true, "Xóa khóa học thành công", true, 200);
            }
        }
    }
}
