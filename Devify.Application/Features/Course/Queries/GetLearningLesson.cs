using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetLearningLesson : IRequest<LearningLessonDTO>
    {
        public string slugRequest { get; set; }
        public Guid lessonIdRequest { get; set; }
        public class GetLearningLessonQueryHandler : IRequestHandler<GetLearningLesson, LearningLessonDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetLearningLessonQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<LearningLessonDTO> Handle(GetLearningLesson query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.CourseRepository.GetLearningLesson(query.slugRequest,query.lessonIdRequest);
            }
        }
    }
}
