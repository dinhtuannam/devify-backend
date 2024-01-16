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
                    return new ApiResponse(false, "you dont have permission to access", false, 403);
                }
                DetailCourseDTO course = _unitOfWork.course.GetCourse(query.code);
                if (string.IsNullOrEmpty(course.code) || string.IsNullOrEmpty(course.creator.code))
                {
                    return new ApiResponse(false, "course not found", false, 404);
                }
                if(query.role.CompareTo("creator") == 0 && course.creator.code.CompareTo(query.user) != 0)
                {
                    return new ApiResponse(false, "you dont have permission to access", false, 403);
                }
                bool result = await _unitOfWork.course.deleteCourse(query.code);
                if (!result)
                {
                    return new ApiResponse(false, "delete course failed", false, 400);
                }
                return new ApiResponse(true, "delete course successfully", true, 200);
            }
        }
    }
}
