using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetDetailCourseBySlug : IRequest<Detail_Course_DTO>
    {
        public string Slug { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetDetailCourseBySlug, Detail_Course_DTO>
        {
            private readonly ICourseRepository _courseService;
            public GetProductByIdQueryHandler(ICourseRepository courseService)
            {
                _courseService = courseService;
            }
            public async Task<Detail_Course_DTO> Handle(GetDetailCourseBySlug query, CancellationToken cancellationToken)
            {
                return await _courseService.GetCourseBySlug(query.Slug);
            }
        }

    }
    
}
