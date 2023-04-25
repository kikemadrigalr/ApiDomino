using ApiDomino.Models;
using Microsoft.AspNetCore.Mvc;
using ApiDomino.Recursos;
using ApiDomino.Controllers;
using Microsoft.EntityFrameworkCore;
using ApiDomino.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ApiDomino.Controllers
{
    //Controlador para manejar las peticiones de los tipos ficha
    //solo tiene un unico endpoint ya que solo se hace insercion de fichas para crear las cadenas de dominoes validas.
    //la inserción a la BD se realiza luego de crear una cadena valida.
    [EnableCors("ReglasCors")]
    [Route("/api/[controller]")]
    [Authorize]
    public class FichaController : ControllerBase
    {
        //se inyecta el contexto de la base de datos como dependencia en el contructor del controlador
        private readonly DominoContext _context;

        public FichaController(DominoContext context)
        {
            _context = context;
        }

        //Enpoint para recibir el conjunto de fichas de dominos en formato Json
        [HttpPost]
        [Route("FichasJuego")]
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
