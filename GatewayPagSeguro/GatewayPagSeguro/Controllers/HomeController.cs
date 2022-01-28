using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GatewayPagSeguro.DTO;
using GatewayPagSeguro.Models;
using GatewayPagSeguro.PagSeguroDTO;
using GatewayPagSeguro.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.Xml;

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

            novalista.Add(new PagSeguroItemDTO() { itemAmount = "55", itemDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam accumsan massa lorem, egestas iaculis sapien egestas at.", itemId = "1", itemQuantity = "1", itemWeight = "1" });
            novalista.Add(new PagSeguroItemDTO() { itemAmount = "69", itemDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam accumsan massa lorem, egestas iaculis sapien egestas at.", itemId = "2", itemQuantity = "1", itemWeight = "1" });
            novalista.Add(new PagSeguroItemDTO() { itemAmount = "150", itemDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam accumsan massa lorem, egestas iaculis sapien egestas at.", itemId = "3", itemQuantity = "1", itemWeight = "1" });

            return novalista;
        }

        public async Task<JsonResult> EnviarDados(ProdutosViewModel model)
        {
            var list = new List<PagSeguroItemDTO>();
            list = MockProdutos();

            var produto = ConverterParaProdutosPagSeguro(list);
            var comprador = ConverterParaCompradorPagSeguro(model.Comprador);

            var servicePagSeguro = new PagSeguroMyService();
            var json = servicePagSeguro.MontarJson(produto, comprador);
                       
            var urlCheckout = MontarURL();
            
            var client = new RestClient();           
            var request = new RestRequest($"{urlCheckout}", Method.Post).AddJsonBody(json);
            request.AddHeader("Content-Type","application/json");
            
            try
            {
              var result = await client.PostAsync(request);
            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
            }
         
            return new JsonResult("");
        }

        private string MontarURL()
        {
            var token = "3167402208B94278A333A53C42F12D0B";
            var email = "renatobordinigarbim@hotmail.com";
            var url = "https://ws.sandbox.pagseguro.uol.com.br/v2/checkout";

            return $"{url}?email={email}&token={token}";
        }

        private Item ConverterParaProdutosPagSeguro(List<PagSeguroItemDTO> produtos)
        {

            //var lista = new List<Item>();            
            var objeto = new Item()
            {
                Id = produtos.FirstOrDefault().itemId,
                Amount = produtos.FirstOrDefault().itemAmount,
                Description = produtos.FirstOrDefault().itemDescription,
                Quantity = produtos.FirstOrDefault().itemQuantity,
                Weight = produtos.FirstOrDefault().itemWeight
            };

            //produtos.ForEach(x => 
            //    lista.Add(new Item() {
            //        Id = x.itemId,
            //        Amount = x.itemAmount,
            //        Description = x.itemDescription,
            //        Quantity = x.itemQuantity,
            //        Weight = x.itemWeight
            //    }));;


            return objeto;
        }

        private Sender ConverterParaCompradorPagSeguro(PagSeguroCompradorDTO dadosComprador)
        {
            var objeto = new Sender();

            objeto.Name = dadosComprador.SenderName;
            objeto.Email = dadosComprador.senderEmail;
            objeto.Phonenumber = dadosComprador.senderPhone;

            return objeto;
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
