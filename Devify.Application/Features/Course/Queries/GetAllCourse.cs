using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetAllCourse : IRequest<DataListDTO<IEnumerable<All_Course_List>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllCourse, DataListDTO<IEnumerable<All_Course_List>> >
        {
            private readonly ICourseRepository _courseRepository;
            public GetAllProductsQueryHandler(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }
            public async Task<DataListDTO<IEnumerable<All_Course_List>>> Handle(GetAllCourse query, CancellationToken cancellationToken)
            {
                return await _courseRepository.GetAllCourse();
            }
        }
    }
}
