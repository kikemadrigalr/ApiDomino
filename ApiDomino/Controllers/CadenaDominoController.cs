using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDomino.Models;
using ApiDomino.Data;
using ApiDomino.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ApiDomino.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]
    public class CadenaDominoController : ControllerBase
    {
        //Se inyecta el servicio para manejar las cadenas como dependencia en el constructor del controlador
        private readonly ICadenaDominoServices cadenaDominoServices;

        public CadenaDominoController(ICadenaDominoServices services)
        {
            cadenaDominoServices = services;
        }

        //Endopoint para listar todas las cadenas válidas que se encuentran en la Base de datos
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

        //Endopoint para listar una unica cadena valida segun su id y que se encuentra en la base de datos
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
