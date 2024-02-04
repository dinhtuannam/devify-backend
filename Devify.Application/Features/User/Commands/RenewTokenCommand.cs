using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.User.Commands
{
    public class RenewTokenCommand : IRequest<ApiResponse>
    {
        public string refreshToken { get; set; } = "";
        public RenewTokenCommand(string refreshToken)
        {
            this.refreshToken = refreshToken;
        }

        public class Handler : IRequestHandler<RenewTokenCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(RenewTokenCommand query, CancellationToken cancellationToken)
            {
                TokenDTO token = await _unitOfWork.token.RenewToken(query.refreshToken);
                if(string.IsNullOrEmpty(token.AccessToken) || string.IsNullOrEmpty(token.RefreshToken))
                {
                    return new ApiResponse(false, "Renew token failed", token, 400);
                }
                return new ApiResponse(true, "Renew token successfully", token, 200);
            }
        }
    }
}
