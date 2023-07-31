using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.Course.Queries
{
    public class GetLearningCourse : IRequest<LearningCourseDTO>
    {
        public string Slug { get; set; }
        public class GetLearningCourseHandler : IRequestHandler<GetLearningCourse, LearningCourseDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetLearningCourseHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<LearningCourseDTO> Handle(GetLearningCourse query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.CourseRepository.GetLearningCourse(query.Slug);
            }
        }
    }
}
