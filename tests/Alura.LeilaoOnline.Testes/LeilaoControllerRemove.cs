using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Controllers;
using Alura.LeilaoOnline.WebApp.Services.Handlers;
using Alura.LeilaoOnline.WebApp.Dados.EfCore;

namespace Alura.LeilaoOnline.Testes
{
    public class LeilaoControllerRemove
    {
        [Fact]
        public void DadoLeilaoInexistenteEntaoRetorna404()
        {
            // arrange
            var idLeilaoInexistente = 11232; // preciso entrar no banco para saber qual é inexistente!! teste deixa de ser automático...
            var actionResultEsperado = typeof(NotFoundResult);
            var daoCategory = new CategoriaDao();
            var daoLeilao = new LeilaoDao();
            var service = new DefaultAdminService(daoLeilao,daoCategory);
            var controller = new LeilaoController(service);

            // act
            var result = controller.Remove(idLeilaoInexistente);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmPregaoEntaoRetorna405()
        {
            // arrange
            var idLeilaoEmPregao = 11232; // qual leilao está em pregão???!! 
            var actionResultEsperado = typeof(StatusCodeResult);
            var daoCategory = new CategoriaDao();
            var daoLeilao = new LeilaoDao();
            var service = new DefaultAdminService(daoLeilao, daoCategory);
            var controller = new LeilaoController(service);

            // act
            var result = controller.Remove(idLeilaoEmPregao);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmRascunhoEntaoExcluiORegistro()
        {
            // arrange
            var idLeilaoEmRascunho = 11232; // qual leilao está em rascunho???!!
            var actionResultEsperado = typeof(NoContentResult);
            var daoCategory = new CategoriaDao();
            var daoLeilao = new LeilaoDao();
            var service = new DefaultAdminService(daoLeilao, daoCategory);
            var controller = new LeilaoController(service);

            // act
            var result = controller.Remove(idLeilaoEmRascunho);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }
    }
}
