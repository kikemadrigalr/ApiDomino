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
        [Route("CadenaValida")]
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

        [HttpGet]
        [Route("CadenaValida/{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                return Ok(cadenaDominoServices.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpDelete("CadenaValida/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                cadenaDominoServices.Delete(id);
                return Ok("La cadena Fue eliminada con Exito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

    }
}
