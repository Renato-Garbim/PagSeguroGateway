using GatewayPagSeguro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayPagSeguro.Models
{
    public class ProdutosViewModel
    {
        public IEnumerable<PagSeguroItemDTO> ListaProdutos { get; set; }
        public PagSeguroCompradorDTO Comprador { get; set; }
        public bool ProdutoA { get; set; }
        public bool ProdutoB { get; set; }
        public bool ProdutoC { get; set; }
    }
}
