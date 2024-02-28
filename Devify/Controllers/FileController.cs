using Devify.Application.DTO;
using Devify.Application.Features.Cart.Queries;
using Devify.Application.Interfaces;
using Devify.Entity.Enums;
using Devify.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IUnitOfWork _firebase;
        public FileController(IUnitOfWork firebase)
        {
            _firebase = firebase;
        }

        [HttpPost]
        [Route("add-image")]
        public async Task<IActionResult> addImage(IFormFile videoFile)
        {
            try
            {
                if (videoFile == null || videoFile.Length == 0)
                {
                    return BadRequest("Invalid file");
                }
                using (var stream = videoFile.OpenReadStream())
                {
                    string fileName = DateTime.Now.Ticks+"-"+videoFile.FileName;
                    string firebaseUrl = await _firebase.file.UploadImage(stream, fileName);

                    if (!string.IsNullOrEmpty(firebaseUrl))
                    {
                        return Ok(new { FirebaseUrl = firebaseUrl });
                    }
                    else
                    {
                        return StatusCode(500, "Failed to upload to Firebase");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("add-video")]
        public async Task<IActionResult> addVideo(IFormFile videoFile)
        {
            try
            {
                if (videoFile == null || videoFile.Length == 0)
                {
                    return BadRequest("Invalid file");
                }
                using (var stream = videoFile.OpenReadStream())
                {
                    string fileName = DateTime.Now.Ticks + "-" + videoFile.FileName;
                    string firebaseUrl = await _firebase.file.UploadVideo(stream, fileName);

                    if (!string.IsNullOrEmpty(firebaseUrl))
                    {
                        return Ok(new { FirebaseUrl = firebaseUrl });
                    }
                    else
                    {
                        return StatusCode(500, "Failed to upload to Firebase");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("remove-image")]
        public async Task<IActionResult> removeImage([FromBody] string path)
        {
            bool result = await _firebase.file.Delete(path,FileEnum.Image);
            return Ok(result);
        }

        [HttpDelete]
        [Route("remove-video")]
        public async Task<IActionResult> removeVideo([FromBody] string path)
        {
            bool result = await _firebase.file.Delete(path, FileEnum.Video);
            return Ok(result);
        }
    }
}
