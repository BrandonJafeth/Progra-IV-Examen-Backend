using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Menus;
using Services.Routes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examen_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly ISvMenu _svMenu;

        public MenuController(ISvMenu svMenu)
        {
            _svMenu = svMenu;
        }

        // GET: api/<MenuController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetRoutes()
        {
           
                var menus = await _svMenu.GetAllMenusAsync();
                return Ok(menus);
        
    }

    }
}
