using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        readonly ILeilaoDao _dao;
        readonly ICategoriaDao _categoryDao;

        public DefaultAdminService(ILeilaoDao dao, ICategoriaDao categoryDao)
        {
            _dao = dao;
            _categoryDao = categoryDao;
        }
        
        public IEnumerable<Leilao> GetAllAuctions()
        {
            return _dao.GetAll();
        }

        public IEnumerable<Categoria> GetAllCategory()
        {
            return _categoryDao.GetAll();
        }

        public Leilao GetAuction(int id)
        {
            return _dao.GetById(id);
        }

        public void InsertAuction(Leilao auction)
        {
            _dao.Insert(auction);
        }

        public void UpdateAuction(Leilao auction)
        {
            _dao.Update(auction);
        }

        public void DeleteAuction(Leilao leilao)
        {
            _dao.Delete(leilao);
        }

        public void StartAuctionSessionWithId(int id)
        {
            var auction = _dao.GetById(id);
            if (auction != null && auction.Situacao == SituacaoLeilao.Rascunho)
            {
                auction.Situacao = SituacaoLeilao.Pregao;
                auction.Inicio = DateTime.Now;
                _dao.Update(auction);
            }
        }

        public void FinishAuctionSessionWithId(int id)
        {
            var auction = _dao.GetById(id);
            if(auction != null && auction.Situacao == SituacaoLeilao.Pregao)
            {
                auction.Situacao = SituacaoLeilao.Finalizado;
                auction.Termino = DateTime.Now;
                _dao.Update(auction);
            }
        }
    }
}
