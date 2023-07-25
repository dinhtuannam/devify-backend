using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Course.Commands
{
    public class CreateCourseCommand : IRequest<bool>
    {
        string name;
        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateCourseCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
            {
                return true;
            }
        }
    }
}
