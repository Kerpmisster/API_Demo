using API_DEMO.DTOs.Order;
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
    public class RolesController : ControllerBase
    {
        public readonly IRoleRepository _roleRepository;
        public RolesController(IRoleRepository rolesRepository) 
        {
            _roleRepository = rolesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await _roleRepository.GetAllAsync();
                var ordersDTOs = roles.Select(u => u.ToRoleFromDTOs());

                return Ok(ordersDTOs);
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
                var roles = await _roleRepository.GetByIdAsync(id);

                if (roles == null)
                {
                    return BadRequest();
                }

                return Ok(roles.ToRoleFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleDTOs rolesDTOs)
        {
            try
            {             
                var rolesModel = rolesDTOs.ToRoleCreateFromDTOs();
                await _roleRepository.CreateAsync(rolesModel);
                return CreatedAtAction(nameof(GetById), new { id = rolesModel.RoleId }, rolesModel.ToRoleFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoleDTOs rolesDTOs, [FromQuery] Role roles)
        {
            try
            {
                if (id != roles.RoleId)
                {
                    return BadRequest("Id không khớp");
                }
                var rolesModel = await _roleRepository.UpdateAsync(id, rolesDTOs.ToRoleUpdateFromDTOs());

                if (rolesModel == null)
                {
                    return NotFound();
                }

                return Ok(rolesModel.ToRoleFromDTOs());
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
                var rolesDelete = await _roleRepository.DeleteAsync(id);

                if (rolesDelete == null)
                {
                    return NotFound();
                }

                return Ok(rolesDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }
    }
}
