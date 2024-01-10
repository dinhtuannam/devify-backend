using Devify.Application.DTO;
using MediatR;

namespace Devify.Application.Features.Course.Commands
{
    public class UpdateCourseCommand : IRequest<ApiResponse>
    {
        public UpdateCourseRequest Request { get; set; }
    }
}
