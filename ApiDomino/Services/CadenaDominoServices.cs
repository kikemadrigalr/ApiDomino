using System.Threading;
using ApiDomino.Data;
using ApiDomino.Models;

namespace ApiDomino.Services
{
    //Servicio para manejar los accesos a datos de las cadenas validas
    //Listar, Buscar por su id y eliminar en la BD
    //No se hace inserción desde aca, ni modificación ya que queda fuera de la logica del servicio solicitado
    public class CadenaDominoServices : ICadenaDominoServices
    {
        public readonly DominoContext _context;

        public CadenaDominoServices(DominoContext context)
        {
            _context = context;
        }

        //metodo para listar todas las cadenas validas que se encuentran en la BD
        public IEnumerable<CadenaDomino> GetAll()
        {
            return _context.CadenaDominos.ToList();
        }

        //Listar una cadena valida de acuerdo al Id suministrado en el endpoint
        public CadenaDomino GetById(int id)
        {
            var cadenaActual = _context.CadenaDominos.Find(id);
            return cadenaActual;
        }

        //Eliminar una cadena valida de la base de datos de acuerdo al id que se recibe en el endpoint
        public async Task Delete(int id)
        {
            var cadenaActual = _context.CadenaDominos.Find(id);

            if(cadenaActual != null)
            {
                _context.CadenaDominos.Remove(cadenaActual);
                await _context.SaveChangesAsync();
            }
        }

    }

    //Interfaz para definir los metodos que debe implementar el servicio
    //al ser un unico servicio y una unica interfaz se decide tenerlos en el mismo archivo
    public interface ICadenaDominoServices
    {
        IEnumerable<CadenaDomino> GetAll();

        CadenaDomino GetById(int id);

        Task Delete(int id);
    }
}
