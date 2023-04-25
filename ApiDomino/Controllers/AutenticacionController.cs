using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiDomino.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ApiDomino.Data;
using System.Text;
using ApiDomino.Recursos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace ApiDomino.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secretKey;
        private readonly DominoContext _context;

        //se obtiene la secretkey del arhivo appsettings en el constructor del controlador
        public AutenticacionController(IConfiguration config, DominoContext context)
        {
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
            _context = context;
        }

        //metodo para autenticar usuario
        [HttpPost]
        [Route("Validar")]
        public IActionResult Validar([FromBody] Usuario request)
        {
            request.Password = Utilidades.EncriptarPassword(request.Password);

            var usuarioActual = _context.Usuario.FirstOrDefault(u => (u.Email == request.Email && u.Password == request.Password));

            if ( usuarioActual != null && ( usuarioActual.Email == request.Email && usuarioActual.Password == request.Password ) )
            {
                var keyBytes =Encoding.ASCII.GetBytes(secretKey);

                //crear solicitudes de permisos con claims
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreated = tokenHandler.WriteToken(tokenConfig);

                //return StatusCode(StatusCodes.Status200OK, new { tokenCreated });
                return Ok(new { token =  tokenCreated });
            }
            else
            {
                return BadRequest(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
