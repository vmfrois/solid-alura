using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        LeilaoDao _dao;

        public LeilaoApiController()
        {
            _dao = new LeilaoDao();
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leioes = _dao.GetAllAuction();
            return Ok(leioes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _dao.GetById(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _dao.Insert(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _dao.Update(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _dao.GetById(id);
            if (leilao == null)
            {
                return NotFound();
            }
            _dao.Delete(leilao.Id);
            return NoContent();
        }


    }
}
