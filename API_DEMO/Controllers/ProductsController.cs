using API_DEMO.DTOs.User;
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
    public class ProductsController : ControllerBase
    {
        public readonly ICategoryRepository CategoryRepository;
        public readonly IProductRepository ProductRepository;
        public ProductsController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await ProductRepository.GetAllAsync();
                var productsDTOs = products.Select(u => u.ToProductFromDTOs());

                return Ok(productsDTOs);
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
                var products = await ProductRepository.GetByIdAsync(id);

                if (products == null)
                {
                    return BadRequest();
                }

                return Ok(products.ToProductFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        //[HttpPost("{roleId:int}")]
        //public async Task<IActionResult> Create([FromRoute] int roleId, CreateUserDTOs userDTOs)
        //{
        //    try
        //    {
        //        if (!await _roleRepository.RoleExists(roleId))
        //        {
        //            return BadRequest("Quyền này không tồn tại");
        //        }

        //        var usersModel = userDTOs.ToUserCreateFromDTOs(roleId);
        //        await _userRepository.CreateAsync(usersModel);
        //        return CreatedAtAction(nameof(GetById), new { id = usersModel.Id }, usersModel.ToUserDTOs());
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Lỗi nhận dữ liệu từ database");
        //    }
        //}

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDTOs userDTOs, User users)
        //{
        //    try
        //    {
        //        if (id != users.Id)
        //        {
        //            return BadRequest("Id không khớp");
        //        }
        //        var userModel = await _userRepository.UpdateAsync(id, userDTOs.ToUserUpdateFromDTOs());

        //        if (userModel == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(userModel.ToUserDTOs());
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Lỗi nhận dữ liệu từ database");
        //    }
        //}

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var productsDelete = await ProductRepository.DeleteAsync(id);

                if (productsDelete == null)
                {
                    return NotFound();
                }

                return Ok(productsDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }
    }
}
