using Devify.Application.DTO;
using Devify.Application.Features.Course.Queries;
using Devify.Application.Interfaces;
using Devify.Entity.Enums;
using MediatR;

namespace Devify.Application.Features.Creator.Queries
{
    public class GetCreatorByConditionQuery : IRequest<DetailCreatorDTO>
    {
        public string condition { get; set; }
        public ConditionEnum type { get; set; }

        public class GetCreatorByConditionQueryHandler : IRequestHandler<GetCreatorByConditionQuery, DetailCreatorDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetCreatorByConditionQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<DetailCreatorDTO> Handle(GetCreatorByConditionQuery query, CancellationToken cancellationToken)
            {
                var result = new DetailCreatorDTO();
                if(query.type == ConditionEnum.SLUG)
                    result = await _unitOfWork.CreatorRepository.GetCreatorBySlug(query.condition);
                if (query.type == ConditionEnum.ID)
                    result = await _unitOfWork.CreatorRepository.GetDetailCreator(query.condition);
                return result;
            }
        }

    }
}
