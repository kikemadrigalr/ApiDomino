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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save(CadenaDomino nuevacadena)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICadenaDominoServices
    {
        IEnumerable<CadenaDomino> GetAll();

        Task GetById(int id);

        Task Save(CadenaDomino nuevacadena);

        //Task Update(Guid id, Tarea tarea);

        Task Delete(int id);
    }
}
