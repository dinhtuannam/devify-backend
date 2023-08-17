using Devify.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Account.Queries
{
    internal class GetDetailUserQuery : IRequest<DetailAccountDTO>
    {
    }
}
