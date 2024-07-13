using API_DEMO.DTOs.Order;
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
    public class OrdersController : ControllerBase
    {
        public readonly IOrdersRepository ordersRepository;
        public readonly IUserRepository userRepository;
        public OrdersController(IOrdersRepository ordersRepository, IUserRepository userRepository)
        {
            this.ordersRepository = ordersRepository;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await ordersRepository.GetAllAsync();
                var ordersDTOs = orders.Select(u => u.ToOrderFromDTOs());

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
                var orders = await ordersRepository.GetByIdAsync(id);

                if (orders == null)
                {
                    return BadRequest();
                }

                return Ok(orders.ToOrderFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPost("{Id:int}")]
        public async Task<IActionResult> Create(int Id, CreateOrderDTOs ordersDTOs)
        {
            try
            {
                if (!await userRepository.UserExists(Id))
                {
                    return BadRequest("Người này không tồn tại");
                }

                var ordersModel = ordersDTOs.ToOrderCreateFromDTOs(Id);
                await ordersRepository.CreateAsync(ordersModel);
                return CreatedAtAction(nameof(GetById), new { id = ordersModel.OrdersId }, ordersModel.ToOrderFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderDTOs ordersDTOs, [FromQuery] Order orders)
        {
            try
            {
                if (id != orders.OrdersId)
                {
                    return BadRequest("Id không khớp");
                }
                var ordersModel = await ordersRepository.UpdateAsync(id, ordersDTOs.ToOrderUpdateFromDTOs());

                if (ordersModel == null)
                {
                    return NotFound();
                }

                return Ok(ordersModel.ToOrderFromDTOs());
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
                var ordersDelete = await ordersRepository.DeleteAsync(id);

                if (ordersDelete == null)
                {
                    return NotFound();
                }

                return Ok(ordersDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }
    }
}
