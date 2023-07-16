using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetAllCourse : IRequest<IEnumerable<Devify.Entity.Course>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllCourse, IEnumerable<Devify.Entity.Course>>
        {
            private readonly ICourseRepository _courseRepository;
            public GetAllProductsQueryHandler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }
            public async Task<IEnumerable<Devify.Entity.Course>> Handle(GetAllCourse query, CancellationToken cancellationToken)
            {
                return await _courseRepository.GetAllCourse();
            }
        }
    }
}
