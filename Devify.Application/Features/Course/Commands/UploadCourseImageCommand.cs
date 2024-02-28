using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity.Enums;
using Devify.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Course.Commands
{
    public class UploadCourseImageCommand : IRequest<ApiResponse>
    {
        public string code { get; set; }
        public IFormFile file { get; set; }

        public UploadCourseImageCommand(string code, IFormFile file)
        {
            this.code = code;
            this.file = file;
        }

        public class Handler : IRequestHandler<UploadCourseImageCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(UploadCourseImageCommand query, CancellationToken cancellationToken)
            {
                try
                {
                    if (query.file == null || query.file.Length == 0)
                    {
                        return new ApiResponse(false, "Tệp không hợp lệ", "", 400);
                    }
                    using (var stream = query.file.OpenReadStream())
                    {
                        SqlCourse? course = _unitOfWork.course.GetRawEntityByCode(query.code);
                        if (course == null || course.isdeleted == true)
                        {
                            return new ApiResponse(false, "Không tìm thấy khóa học", "", 404);
                        }
                        string fileName = query.file.FileName + "-" + DateTime.Now.Ticks;
                        string firebaseUrl = await _unitOfWork.file.UploadImage(stream, fileName);

                        if (string.IsNullOrEmpty(firebaseUrl))
                        {
                            return new ApiResponse(false, "Tệp không hợp lệ", "", 400);
                        }
                        if (course.image.CompareTo(ConfigKey.DEFAULT_COURSE_BG) != 0)
                        {
                            await _unitOfWork.file.Delete(course.image, FileEnum.Image);
                        }
                        course.image = firebaseUrl;
                        await _unitOfWork.CompleteAsync();
                        return new ApiResponse(true, "Cập nhật hình ảnh thành công", firebaseUrl, 200);
                    }
                }
                catch (Exception ex)
                {
                    return new ApiResponse(false, "Tệp không hợp lệ", "", 400);
                }
            }
        }
    }
}
