using API_DEMO.DTOs.OrderDetail;
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
    public class OrdersDetailsController : ControllerBase
    {
        public readonly IOrdersDetailRepository ordersDetailRepository;
        public readonly IOrdersRepository ordersRepository;
        public OrdersDetailsController(IOrdersDetailRepository ordersDetailRepository, IOrdersRepository ordersRepository)
        {
            this.ordersDetailRepository = ordersDetailRepository;
            this.ordersRepository = ordersRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ordersDetails = await ordersDetailRepository.GetAllAsync();
                var ordersDetailDTOs = ordersDetails.Select(u => u.ToOrderDetailFromDTOs());

                return Ok(ordersDetailDTOs);
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
                var ordersDetails = await ordersDetailRepository.GetByIdAsync(id);

                if (ordersDetails == null)
                {
                    return BadRequest();
                }

                return Ok(ordersDetails.ToOrderDetailFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPost("{orderId:int}")]
        public async Task<IActionResult> Create(int orderId, CreateOrderDetailDTOs ordersDetailsDTOs)
        {
            try
            {
                if (!await ordersRepository.OrderExists(orderId))
                {
                    return BadRequest("Đơn hàng này không tồn tại");
                }

                var ordersDetailsModel = ordersDetailsDTOs.ToOrderDetailCreateFromDTOs(orderId);
                await ordersDetailRepository.CreateAsync(ordersDetailsModel);
                return CreatedAtAction(nameof(GetById), new { id = ordersDetailsModel.Id }, ordersDetailsModel.ToOrderDetailFromDTOs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderDetailDTOs orderDetailDTOs, [FromQuery] OrdersDetail ordersDetails)
        {
            try
            {
                if (id != ordersDetails.Id)
                {
                    return BadRequest("Id không khớp");
                }
                var ordersDetailsModel = await ordersDetailRepository.UpdateAsync(id, orderDetailDTOs.ToOrderDetailUpdateFromDTOs());

                if (ordersDetailsModel == null)
                {
                    return NotFound();
                }

                return Ok(ordersDetailsModel.ToOrderDetailFromDTOs());
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
                var ordersDetailDelete = await ordersDetailRepository.DeleteAsync(id);

                if (ordersDetailDelete == null)
                {
                    return NotFound();
                }

                return Ok(ordersDetailDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi nhận dữ liệu từ database");
            }
        }
    }
}
