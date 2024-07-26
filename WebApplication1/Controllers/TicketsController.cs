using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Tickets;
using System;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ISvTicket _svTicket;

        public TicketController(ISvTicket svTicket)
        {
            _svTicket = svTicket;
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody] DTOTicket dtoTicket)
        {
            try
            {
                var addedTicket = await _svTicket.AddTicketAsync(dtoTicket);
                return Ok(addedTicket);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("PersonsByRoute")]
        public async Task<IActionResult> GetPersonsByRoute([FromQuery] string departureRoute, [FromQuery] string destinationRoute)
        {
            try
            {
                var personCount = await _svTicket.GetPersonsTraveledByRouteAsync(departureRoute, destinationRoute);
                return Ok(new { personCount = personCount });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("PersonsByDate")]
        public async Task<IActionResult> GetPersonsByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var personCount = await _svTicket.GetPersonsTraveledByDateAsync(startDate, endDate);
                return Ok(new { personCount = personCount });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }


        }
        [HttpGet("TotalCollectedByRoute")]
        public async Task<IActionResult> GetTotalCollectedByRoute([FromQuery] string departureRoute, [FromQuery] string destinationRoute)
        {
            try
            {
                var totalCollected = await _svTicket.GetTotalCollectedByRouteAsync(departureRoute, destinationRoute);
                return Ok(new { totalCollected = totalCollected });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("TotalCollectedByDate")]
        public async Task<IActionResult> GetTotalCollectedByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var totalCollected = await _svTicket.GetTotalCollectedByDateAsync(startDate, endDate);
                return Ok(new { totalCollected = totalCollected });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
