using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GatewayPagSeguro.DTO;
using GatewayPagSeguro.Models;
using GatewayPagSeguro.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedCode.PagSeguro;

namespace GatewayPagSeguro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new ProdutosViewModel();
            model.ListaProdutos = MockProdutos();

            return View(model);
        }

        private List<PagSeguroItemDTO> MockProdutos()
        {
            var novalista = new List<PagSeguroItemDTO>();

            novalista.Add(new PagSeguroItemDTO() { itemAmount = "55", itemDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam accumsan massa lorem, egestas iaculis sapien egestas at.", itemId = "1", itemQuantity ="1", itemWeight = "1" });
            novalista.Add(new PagSeguroItemDTO() { itemAmount = "69", itemDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam accumsan massa lorem, egestas iaculis sapien egestas at.", itemId = "2", itemQuantity = "1", itemWeight = "1" });
            novalista.Add(new PagSeguroItemDTO() { itemAmount = "150", itemDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam accumsan massa lorem, egestas iaculis sapien egestas at.", itemId = "3", itemQuantity = "1", itemWeight = "1" });

            return novalista;
        }

        public IActionResult EnviarDados()
        {
            var list = new List<PagSeguroItemDTO>();
            var comprador = new PagSeguroCompradorDTO();

             var token = "850fc82c-a5d8-4dfe-87a5-3ca590387ef4de918bdb4707a666783cf1179af87d2c3fba-7ae5-4c36-8717-edaa7724576f";
             var email = "renatobordinigarbim@hotmail.com";
             var url = "https://ws.sandbox.pagseguro.uol.com.br/v2/transactions?";

            var servicePagSeguro = new PagSeguroAPI();
            var result = servicePagSeguro.Checkout(email, token, url, list, comprador, "");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
