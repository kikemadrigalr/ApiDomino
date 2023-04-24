using ApiDomino.Data;
using ApiDomino.Models;

namespace ApiDomino.Services
{
    public class FichaServices : IFichaServices
    {
        public readonly DominoContext _context;

        public FichaServices(DominoContext context)
        {
            _context = context;
        }

        public Task Cadena(List<Ficha> nuevacadena)
        {
            throw new NotImplementedException();
        }
    }

    public interface IFichaServices
    {
        Task Cadena(List<Ficha> nuevacadena);
    }
}
