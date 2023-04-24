using ApiDomino.Models;
using Microsoft.AspNetCore.Mvc;
using ApiDomino.Recursos;

namespace ApiDomino.Controllers
{
    [Route("/api/[controller]")]
    public class FichaController : ControllerBase
    {

        [HttpPost]
        [Route("Cadena")]
        public IActionResult Cadena([FromBody] Ficha[] fichas) 
        {
            List<Ficha> fichasJuego = fichas.ToList();
            var nuevaCadena = new List<Ficha>();

            if (fichasJuego.Count < 2 || fichasJuego.Count > 6)
            {
                //Console.WriteLine("El total de fichas del juego son 28, Ingrese 28 fichas o menos");
                return BadRequest("Ingrese un numero de Fichas entre 2 y 6");
            }
            else
            {
                if (Utilidades.BuildDominoChain(fichasJuego, nuevaCadena))
                {
                    //Console.WriteLine("La siguiente Cadena es una cadena Valida");
                    //foreach (var ficha in nuevaCadena)
                    //{
                    //    Console.Write(ficha);
                    return Ok("La cadena fue creada correctamente");
                    //}
                }
                else
                {
                    //foreach (var ficha in nuevaCadena)
                    //{
                    //    Console.Write(ficha);
                    //}
                    //Console.WriteLine("No se pudo construir una cadena válida.");
                    return BadRequest("No Se pudo construir una cadena válida");
                }
            }
        }
    }
}
