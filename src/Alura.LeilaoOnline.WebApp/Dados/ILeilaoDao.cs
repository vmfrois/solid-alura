using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
        IEnumerable<Leilao> GetAllAuction();
        Leilao GetById(int id);
        void Insert(Leilao leilao);
        void Update(Leilao leilao);
        void Delete(int id);
    }
}
