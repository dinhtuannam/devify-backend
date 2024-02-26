using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;

namespace Devify.Application.Features.Course.Commands
{
    public class UpdateCourseCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public string code { get; set; } = "";  
        public string title { get; set; } = "";
        public string des { get; set; } = "";
        public double price { get; set; } = 0;
        public double salePrice { get; set; } = 0;
        public bool issale { get; set; } = false;
        public string category { get; set; } = "";
        public List<string> languages { get; set; } = new List<string>();
        public List<string> levels { get; set; } = new List<string>();

        public UpdateCourseCommand(string user, string role ,string code,string title, string des, double price, double salePrice, bool issale, string category,List<string> languages, List<string> levels)
        {
            this.user = user;
            this.role = role;
            this.code = code;
            this.title = title;
            this.des = des;
            this.price = price;
            this.salePrice = salePrice;
            this.issale = issale;
            this.category = category;
            this.languages = languages;
            this.levels = levels;
        }

        public class Handler : IRequestHandler<UpdateCourseCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(UpdateCourseCommand query, CancellationToken cancellationToken)
            {
                DetailCourseDTO updatedCourse = new DetailCourseDTO();
                if (string.IsNullOrEmpty(query.user) || string.IsNullOrEmpty(query.role))
                {
                    return new ApiResponse(false, "you dont have permission to access", updatedCourse, 403);
                }
                DetailCourseDTO course = _unitOfWork.course.GetCourse(query.code);
                if (string.IsNullOrEmpty(course.code) || string.IsNullOrEmpty(course.creator.code))
                {
                    return new ApiResponse(false, "course not found", updatedCourse, 404);
                }
                if (query.role.CompareTo("creator") == 0 && course.creator.code.CompareTo(query.user) != 0)
                {
                    return new ApiResponse(false, "you dont have permission to access", updatedCourse, 403);
                }
                SqlCourse? result = await _unitOfWork.course.updateCourse(  query.code,
                                                                            query.title,
                                                                            query.des,
                                                                            query.price,
                                                                            query.salePrice,
                                                                            query.issale,
                                                                            query.category,
                                                                            query.languages,
                                                                            query.levels);
                if (string.IsNullOrEmpty(result.code))
                {
                    return new ApiResponse(false, "update course failed", updatedCourse, 400);
                }
                updatedCourse = _unitOfWork.course.GetCourse(query.code, true);
                updatedCourse.owner = true;
                return new ApiResponse(true, "update course successfully", updatedCourse, 200);
            }
        }
    }
}
