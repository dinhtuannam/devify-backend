using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetDetailCourseBySlug : IRequest<DetailCourseDTO>
    {
        public string Slug { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetDetailCourseBySlug, DetailCourseDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<DetailCourseDTO> Handle(GetDetailCourseBySlug query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.course.GetCourseBySlug(query.Slug);
            }
        }

    }
    
}
