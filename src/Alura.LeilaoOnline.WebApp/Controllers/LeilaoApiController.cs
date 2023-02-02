using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        readonly IAdminService _service;

        public LeilaoApiController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leioes = _service.GetAllAuctions();
            return Ok(leioes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _service.GetAuction(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _service.InsertAuction(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _service.UpdateAuction(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _service.GetAuction(id);
            if (leilao == null)
            {
                return NotFound();
            }
            _service.DeleteAuction(leilao);
            return NoContent();
        }

        [HttpPost("{id}/pregao")]
        public IActionResult EndpointIniciaPregao(int id)
        {
            var leilao = _service.GetAuction(id);
            if (leilao == null) return NotFound();
            _service.StartAuctionSessionWithId(id);
            return Ok();
        }

        [HttpDelete("{id}/pregao")]
        public IActionResult EndpointFinalizaPregao(int id)
        {
            var leilao = _service.GetAuction(id);
            if (leilao == null) return NotFound();
            _service.FinishAuctionSessionWithId(id);
            return Ok();
        }

    }
}
