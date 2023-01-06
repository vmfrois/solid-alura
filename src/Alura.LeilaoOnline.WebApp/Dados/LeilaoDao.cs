using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeilaoDao
    {
        AppDbContext _context;

        public LeilaoDao()
        {
            _context = new AppDbContext();
        }


        public IEnumerable<Categoria> GetAllCategory()
        {
            return _context.Categorias.ToList();
        }

        public IEnumerable<Leilao> GetAllAuction()
        {
            var leiloes = _context.Leiloes
                .Include(l => l.Categoria);
            return leiloes;
        }

        public Leilao GetById(int id)
        {
            var leilao = _context.Leiloes.Find(id);
            return leilao;
        }

        public void Insert(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Update(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var leilao = _context.Leiloes.Find(id);
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }

    }
}
