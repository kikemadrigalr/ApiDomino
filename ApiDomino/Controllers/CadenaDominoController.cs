using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDomino.Models;
using ApiDomino.Data;
using ApiDomino.Services;

namespace ApiDomino.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CadenaDominoController : ControllerBase
    {
        private readonly ICadenaDominoServices cadenaDominoServices;

        public CadenaDominoController(ICadenaDominoServices services)
        {
            cadenaDominoServices = services;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Get() 
        {
            try
            {
                return Ok(cadenaDominoServices.GetAll());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
