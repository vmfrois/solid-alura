using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultProdutoService : IProdutoService
    {
        readonly ILeilaoDao _leilaoDao;
        readonly ICategoriaDao _categoriaDao;

        public DefaultProdutoService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _leilaoDao = leilaoDao;
            _categoriaDao = categoriaDao;
        }

        public Categoria GetCategoryByIdWithAuctionsOnTradingFloor(int id)
        {
            return _categoriaDao.GetById(id);
        }

        public IEnumerable<CategoriaComInfoLeilao> GetCategoryWithTotalAuctionsOnTradingFloor()
        {
            return _categoriaDao.GetAll()
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                });
        }

        public IEnumerable<Leilao> SearchAuctionsOnTradingFloor(string term)
        {
            var termoNormalized = term.ToUpper();
            return _leilaoDao.GetAll()
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descricao.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termoNormalized));
        }
    }
}
