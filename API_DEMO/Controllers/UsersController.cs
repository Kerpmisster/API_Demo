using API_DEMO.DTOs.User;
using API_DEMO.Interface;
using API_DEMO.Mappers;
using API_DEMO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DEMO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UsersController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try 
            {
                var users = await _userRepository.GetAllAsync();
                var userDTOs = users.Select(u => u.ToUserDTOs());

                return Ok(userDTOs);
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
                var users = await _userRepository.GetByIdAsync(id);

                if(users == null)
                {
                    return BadRequest();
                }

                return Ok(users.ToUserDTOs());
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPost("{roleId:int}")]
        public async Task<IActionResult> Create(int roleId, CreateUserDTOs userDTOs)
        {
            try
            {
                if (!await _roleRepository.RoleExists(roleId))
                {
                    return BadRequest("Quyền này không tồn tại");
                }

                var usersModel = userDTOs.ToUserCreateFromDTOs(roleId);
                await _userRepository.CreateAsync(usersModel);
                return CreatedAtAction(nameof(GetById), new {id=usersModel.Id}, usersModel.ToUserDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDTOs userDTOs, [FromQuery] User users)
        {
            try
            {
                if (id != users.Id)
                {
                    return BadRequest("Id không khớp");
                }
                var userModel = await _userRepository.UpdateAsync(id, userDTOs.ToUserUpdateFromDTOs());

                if (userModel == null) 
                {
                    return NotFound();
                }

                return Ok(userModel.ToUserDTOs());
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
                var userDelete = await _userRepository.DeleteAsync(id);

                if (userDelete == null)
                {
                    return NotFound();
                }

                return Ok(userDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }
    }
}
