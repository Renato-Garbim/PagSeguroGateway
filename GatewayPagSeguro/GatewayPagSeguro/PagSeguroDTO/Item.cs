using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayPagSeguro.PagSeguroDTO
{
    public class Item
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Quantity { get; set; }
        public string Weight { get; set; }
    }
}
