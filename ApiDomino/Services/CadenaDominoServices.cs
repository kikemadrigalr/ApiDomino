using System.Threading;
using ApiDomino.Data;
using ApiDomino.Models;

namespace ApiDomino.Services
{
    public class CadenaDominoServices : ICadenaDominoServices
    {
        public readonly DominoContext _context;

        public CadenaDominoServices(DominoContext context)
        {
            _context = context;
        }

        public IEnumerable<CadenaDomino> GetAll()
        {
            return _context.CadenaDominos.ToList();
        }

        public async Task Delete(int id)
        {
            var cadenaActual = _context.CadenaDominos.Find(id);

            if(cadenaActual != null)
            {
                _context.CadenaDominos.Remove(cadenaActual);
                await _context.SaveChangesAsync();
            }
        }

        public CadenaDomino GetById(int id)
        {
            var cadenaActual = _context.CadenaDominos.Find(id);
            return cadenaActual;
        }

    }

    public interface ICadenaDominoServices
    {
        IEnumerable<CadenaDomino> GetAll();

        CadenaDomino GetById(int id);

        Task Delete(int id);
    }
}
