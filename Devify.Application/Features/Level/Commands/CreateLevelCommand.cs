using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;


namespace Devify.Application.Features.Level.Commands
{
    public class CreateLevelCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public CreateLevelCommand(string code, string name,string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }

        public class Handler : IRequestHandler<CreateLevelCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(CreateLevelCommand query, CancellationToken cancellationToken)
            {
                SqlLevel level = await _unitOfWork.level.createLevel(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(level.code))
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Create level failed",
                        code = 400,
                        data = ""
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Create level successfully",
                    code = 0,
                    data = level.code
                };
            }
        }
    }
}
