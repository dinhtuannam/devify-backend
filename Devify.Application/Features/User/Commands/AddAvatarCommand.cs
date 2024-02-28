using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Entity.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.User.Commands
{
    public class AddAvatarCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public IFormFile file { get; set; }

        public AddAvatarCommand(string code, IFormFile file)
        {
            this.code = code;
            this.file = file;
        }

        public class Handler : IRequestHandler<AddAvatarCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(AddAvatarCommand query, CancellationToken cancellationToken)
            {
                try
                {
                    if (query.file == null || query.file.Length == 0)
                    {
                        return new ApiResponse(false, "Tệp không hợp lệ", "", 400);
                    }
                    using (var stream = query.file.OpenReadStream())
                    {
                        SqlUser? user = _unitOfWork.user.GetRawEntityByCode(query.code);
                        if (user == null || user.isdeleted == true)
                        {
                            return new ApiResponse(false, "Không tìm thấy người dùng", "", 404);
                        }
                        string fileName = query.file.FileName+"-"+DateTime.Now.Ticks;
                        string firebaseUrl = await _unitOfWork.file.UploadImage(stream, fileName);

                        if (string.IsNullOrEmpty(firebaseUrl))
                        {
                            return new ApiResponse(false, "Tệp không hợp lệ", "", 400);
                        }
                        if(user.image.CompareTo(ConfigKey.DEFAULT_AVATAR) != 0)
                        {
                            await _unitOfWork.file.Delete(user.image, FileEnum.Image);
                        }
                        user.image = firebaseUrl;
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
