using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IProdutoService
    {
        IEnumerable<Leilao> SearchAuctionsOnTradingFloor(string term);
        IEnumerable<CategoriaComInfoLeilao> GetCategoryWithTotalAuctionsOnTradingFloor();
        Categoria GetCategoryByIdWithAuctionsOnTradingFloor(int id);
    }
}
