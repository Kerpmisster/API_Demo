using API_DEMO.DTOs.Category;
using API_DEMO.DTOs.Role;
using API_DEMO.Interface;
using API_DEMO.Mappers;
using API_DEMO.Models;
using API_DEMO.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DEMO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categorys = await _categoryRepository.GetAllAsync();
                var categorysDTOs = categorys.Select(u => u.ToCategoryFromDTOs());

                return Ok(categorysDTOs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var categorys = await _categoryRepository.GetByIdAsync(id);

                if (categorys == null)
                {
                    return BadRequest();
                }

                return Ok(categorys.ToCategoryFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDTOs categorysDTOs)
        {
            try
            {
                var categorysModel = categorysDTOs.ToCategoryCreateFromDTOs();
                await _categoryRepository.CreateAsync(categorysModel);
                return CreatedAtAction(nameof(GetById), new { id = categorysModel.CategoryId }, categorysModel.ToCategoryFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryDTOs categorysDTOs, [FromQuery] Category categorys)
        {
            try
            {
                if (id != categorys.CategoryId)
                {
                    return BadRequest("Id không khớp");
                }
                var categorysModel = await _categoryRepository.UpdateAsync(id, categorysDTOs.ToCategoryUpdateFromDTOs());

                if (categorysModel == null)
                {
                    return NotFound();
                }

                return Ok(categorysModel.ToCategoryFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var categorysDelete = await _categoryRepository.DeleteAsync(id);

                if (categorysDelete == null)
                {
                    return NotFound();
                }

                return Ok(categorysDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }
    }
}
