using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Course.Queries
{
    public class GetLearningInfoQuery : IRequest<ApiResponse>
    {
        public string course { get; set; } = "";
        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public GetLearningInfoQuery(string course, string user, string role)
        {
            this.course = course;
            this.user = user;
            this.role = role;
        }

        public class Handler : IRequestHandler<GetLearningInfoQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetLearningInfoQuery query, CancellationToken cancellationToken)
            {
                CourseLearningInfo info = new CourseLearningInfo();
                SqlCourse m_course = _unitOfWork.course.GetRawEntityByCode(query.course);
                if(m_course == null)
                {
                    return Task.FromResult(new ApiResponse(false, "Course not found", info, 404));
                }
                info = _unitOfWork.course.getLearningCourseInfo(query.course, query.user);
                if(string.IsNullOrEmpty(info.code))
                {
                    return Task.FromResult(new ApiResponse(false, "Course not found", info, 404));
                }
                return Task.FromResult(new ApiResponse(true, "Get course learning data successfully", info, 200));
            }
        }
    }
}
