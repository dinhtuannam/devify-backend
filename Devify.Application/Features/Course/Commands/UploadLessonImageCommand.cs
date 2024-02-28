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
    public class UploadLessonImageCommand : IRequest<ApiResponse>
    {
        public string code { get; set; }
        public IFormFile file { get; set; }

        public UploadLessonImageCommand(string code, IFormFile file)
        {
            this.code = code;
            this.file = file;
        }

        public class Handler : IRequestHandler<UploadLessonImageCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(UploadLessonImageCommand query, CancellationToken cancellationToken)
            {
                try
                {
                    if (query.file == null || query.file.Length == 0)
                    {
                        return new ApiResponse(false, "Tệp không hợp lệ", "", 400);
                    }
                    using (var stream = query.file.OpenReadStream())
                    {
                        SqlLesson? lesson = _unitOfWork.lesson.GetRawEntityByCode(query.code);
                        if (lesson == null || lesson.isdeleted == true)
                        {
                            return new ApiResponse(false, "Không tìm thấy bài học", "", 404);
                        }
                        string fileName = query.file.FileName + "-" + DateTime.Now.Ticks;
                        string firebaseUrl = await _unitOfWork.file.UploadImage(stream, fileName);

                        if (string.IsNullOrEmpty(firebaseUrl))
                        {
                            return new ApiResponse(false, "Tệp không hợp lệ", "", 400);
                        }
                        if (lesson.image.CompareTo(ConfigKey.DEFAULT_COURSE_BG) != 0)
                        {
                            await _unitOfWork.file.Delete(lesson.image, FileEnum.Image);
                        }
                        lesson.image = firebaseUrl;
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
