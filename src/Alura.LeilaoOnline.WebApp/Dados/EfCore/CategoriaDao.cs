using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class CategoriaDao : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDao()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Categoria> GetAllCategory()
        {
            return _context.Categorias
                .Include(c => c.Leiloes);
        }

        public Categoria GetById(int id)
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
        }
    }
}
