using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class LeilaoDao : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDao()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Leilao> GetAll()
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

        public void Delete(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }

    }
}
