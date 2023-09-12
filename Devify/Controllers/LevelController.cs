using Devify.Application.Commons;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Entity.Enums;
using Devify.Filters;
using Devify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/level")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LevelController(ILogger<LanguageController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLevel()
        {
            var model = await _unitOfWork.LevelRepository.GetAllAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLevel(CreateLevelModel model)
        {
            CourseLevel newLevel = new CourseLevel();
            newLevel.CourseLevelId = AutoGenerate.GenerateID("level", 8);
            newLevel.LevelName = model.LevelName;
            newLevel.LevelDescription = model.LevelDescription;
            newLevel.Status = Entity.Enums.CommonEnum.AVAILABLE;
            newLevel.DateCreated = DateTime.Now;
            newLevel.DateUpdated = DateTime.Now;
            bool res = await _unitOfWork.LevelRepository.AddAsAsync(newLevel);
            if (res)
            {
                await _unitOfWork.CompleteAsync();
                return Ok(new API_Response_VM
                {
                    Success = true,
                    Message = "Create level successfully",
                    ErrCode = "200",
                    Data = newLevel
                });
            }              
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLevel(UpdateLevelModel model)
        {
            CourseLevel m_level = _unitOfWork.LevelRepository.GetByCondition(l => l.CourseLevelId == model.CourseLevelId).FirstOrDefault();
            if (m_level == null)
                return BadRequest();
            m_level.LevelName = model.LevelName;
            m_level.LevelDescription = model.LevelDescription;
            m_level.Status = model.Status;
            m_level.DateUpdated = DateTime.Now;
            bool res = _unitOfWork.LevelRepository.UpdateEntity(m_level);
            if (res)
            {
                await _unitOfWork.CompleteAsync();
                return Ok();
            }   
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLevel(string id)
        {
            CourseLevel m_level = _unitOfWork.LevelRepository.GetByCondition(l => l.CourseLevelId == id).FirstOrDefault();
            if (m_level == null)
                return BadRequest();
            m_level.Status = CommonEnum.DELETED;
            m_level.DateUpdated = DateTime.Now;
            bool res = _unitOfWork.LevelRepository.UpdateEntity(m_level);
            if (res)
            {
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
