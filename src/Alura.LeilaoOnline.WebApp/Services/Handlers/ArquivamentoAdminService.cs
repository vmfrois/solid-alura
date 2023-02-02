using System.Collections.Generic;
using System.Linq;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class ArquivamentoAdminService : IAdminService
    {
        readonly IAdminService _defaultService;

        public ArquivamentoAdminService(ILeilaoDao dao, ICategoriaDao categDao)
        {
            _defaultService = new DefaultAdminService(dao, categDao);
        }

        public void InsertAuction(Leilao leilao)
        {
            _defaultService.InsertAuction(leilao);
        }

        public void UpdateAuction(Leilao leilao)
        {
            _defaultService.UpdateAuction(leilao);
        }

        public void DeleteAuction(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _defaultService.DeleteAuction(leilao);
            }
        }

        public void FinishAuctionSessionWithId(int id)
        {
            _defaultService.FinishAuctionSessionWithId(id);
        }

        public void StartAuctionSessionWithId(int id)
        {
            _defaultService.StartAuctionSessionWithId(id);
        }

        public IEnumerable<Categoria> GetAllCategory()
        {
            return _defaultService.GetAllCategory();
        }

        public IEnumerable<Leilao> GetAllAuctions()
        {
            return _defaultService
                .GetAllAuctions()
                .Where(l => l.Situacao != SituacaoLeilao.Arquivado);
        }

        public Leilao GetAuction(int id)
        {
            return _defaultService.GetAuction(id);
        }
    }
}
