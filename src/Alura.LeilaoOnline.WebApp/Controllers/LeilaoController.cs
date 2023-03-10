using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class LeilaoController : Controller
    {
        readonly IAdminService _service;
        public LeilaoController(IAdminService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var leiloes = _service.GetAllAuctions();
            return View(leiloes);
        } 

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _service.GetAllCategory();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _service.InsertAuction(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _service.GetAllCategory();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _service.GetAllCategory();
            ViewData["Operacao"] = "Edição";
            var leilao = _service.GetAuction(id);
            if (leilao == null) return NotFound();
            return View("Form", leilao);
        }

        [HttpPost]
        public IActionResult Edit(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateAuction(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _service.GetAllCategory();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var leilao = _service.GetAuction(id);
            if (leilao == null) return NotFound();
            _service.StartAuctionSessionWithId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var leilao = _service.GetAuction(id);
            if (leilao == null) return NotFound();
            _service.FinishAuctionSessionWithId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var leilao = _service.GetAuction(id);
            if (leilao == null) return NotFound();
            _service.DeleteAuction(leilao);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _service.GetAllAuctions()
                .Where(l => string.IsNullOrWhiteSpace(termo) || 
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) || 
                    l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", leiloes);
        }
    }
}
