using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetDetailCourseBySlug : IRequest<Devify.Entity.Course>
    {
        public string Slug { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetDetailCourseBySlug, Devify.Entity.Course>
        {
            private readonly ICourseRepository _courseService;
            public GetProductByIdQueryHandler(ICourseRepository courseService)
            {
                _courseService = courseService;
            }
            public async Task<Devify.Entity.Course> Handle(GetDetailCourseBySlug query, CancellationToken cancellationToken)
            {
                return await _courseService.GetCourseBySlug(query.Slug);
            }
        }

    }
    
}
