using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetAllCourse : IRequest<DataListDTO<IEnumerable<AllCourseList>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllCourse, DataListDTO<IEnumerable<AllCourseList>> >
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<DataListDTO<IEnumerable<AllCourseList>>> Handle(GetAllCourse query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.CourseRepository.GetAllCourse();
            }
        }
    }
}
