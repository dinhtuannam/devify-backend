using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Queries
{
    public class GetAllCourse : IRequest<DataListDTO<IEnumerable<All_Course_List>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllCourse, DataListDTO<IEnumerable<All_Course_List>> >
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<DataListDTO<IEnumerable<All_Course_List>>> Handle(GetAllCourse query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.CourseRepository.GetAllCourse();
            }
        }
    }
}
