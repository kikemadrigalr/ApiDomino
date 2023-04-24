using ApiDomino.Models;
using Microsoft.AspNetCore.Mvc;
using ApiDomino.Recursos;
using ApiDomino.Controllers;
using Microsoft.EntityFrameworkCore;
using ApiDomino.Data;

namespace ApiDomino.Controllers
{
    [Route("/api/[controller]")]
    public class FichaController : ControllerBase
    {
        private readonly DominoContext _context;

        public FichaController(DominoContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Cadena")]
        public IActionResult Cadena([FromBody] Ficha[] fichas) 
        {
            List<Ficha> fichasJuego = fichas.ToList();
            var nuevaCadena = new List<Ficha>();

            if (fichasJuego.Count < 2 || fichasJuego.Count > 6)
            {
                return BadRequest("Ingrese un numero de Fichas entre 2 y 6");
            }
            else
            {
                if (Utilidades.BuildDominoChain(fichasJuego, nuevaCadena))
                {
                    string cadenaValida = "";
                    CadenaDomino cadena = new CadenaDomino();

                    foreach(var ficha in nuevaCadena)
                    {
                        cadenaValida += ficha.ToString();
                        cadena.Cadena = cadenaValida;
                        cadena.Fecha = DateTime.Now;
                    }

                    _context.CadenaDominos.AddAsync(cadena);
                    _context.SaveChanges();
                    return Ok("La cadena fue creada correctamente");
                    
                }
                else
                {
                    return BadRequest("No Se pudo construir una cadena válida");
                }
            }
        }
    }
}
