using AutoMapper;
using Devify.Application.Interfaces;
using MediatR;
using Devify.Application.DTO;


namespace Devify.Application.Features.Account.Queries
{
    public class GetUserInformationById : IRequest<Account_Information_DTO>
    {
        public string Id { get; set; }
        public class GetUserInformationByIdHandler : IRequestHandler<GetUserInformationById, Account_Information_DTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public GetUserInformationByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<Account_Information_DTO> Handle(GetUserInformationById query, CancellationToken cancellationToken)
            {
                var account = await _unitOfWork.AccountRepository.getCurrentUser(query.Id);
                var model = _mapper.Map<Account_Information_DTO>(account);
                return model;
            }
        }
    }
}
