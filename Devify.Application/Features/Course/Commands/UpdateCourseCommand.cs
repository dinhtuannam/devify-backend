using Devify.Application.DTO;
using Devify.Application.DTO.ResponseDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Course.Commands
{
    public class UpdateCourseCommand : IRequest<ApiResponse>
    {
        public UpdateCourseRequest Request { get; set; }
    }
}
