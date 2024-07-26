using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Routes; // Asegúrate de incluir el namespace correcto para ISvRoute
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bus_RoutesController : ControllerBase
    {
        private readonly ISvBus_Route _svRoute;

        public Bus_RoutesController(ISvBus_Route svRoute)
        {
            _svRoute = svRoute;
        }

  
        // GET api/<RouteController>/price?from=Lugar1&to=Lugar2
        [HttpGet("price")]
        public ActionResult<float> GetPrice(string from, string to)
        {
            try
            {
                var price = _svRoute.GetPrice(from, to);
                return Ok(price);
            }
            catch (Exception ex)
            {
        
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOBus_Route>>> GetRoutes()
        {
            try
            {
                var routes = await _svRoute.GetAllRoutesAsync();
                return Ok(routes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
