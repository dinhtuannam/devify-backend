using AutoMapper;
using Devify.Application.DTO;
using Devify.Application.Features.Category.Commands;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Filters;
using Devify.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public CategoryController(IMapper mapper, IUnitOfWork unitOfWork,IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        [Cache(3600)]
        public async Task<IActionResult> GetALlCategory()
        {
            var model = await _unitOfWork.CategoryRepository.GetAllAsync();
            return Ok(model);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var model = await _unitOfWork.CategoryRepository.SearchAsAsync(name);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategory([FromForm] CreateCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var newCategory = _mapper.Map<Category>(model);
                var result = await _mediator.Send(new CreateCategoryCommand { newCategory = newCategory});
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new DeleteCategoryCommand { DeleteID = id });
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryModel model)
        {

            if (ModelState.IsValid)
            {
                var updateCategory = _mapper.Map<Category>(model);
                var result = await _mediator.Send(new UpdateCategoryCommand { newCategory = updateCategory });
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
