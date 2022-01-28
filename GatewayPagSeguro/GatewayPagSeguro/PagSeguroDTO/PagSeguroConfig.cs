using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayPagSeguro.PagSeguroDTO
{
    public class PagSeguroConfig
    {
        public string Currency { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Quantity { get; set; }
        public string Weight { get; set; }
        public bool addressRequired { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string phoneareaCode { get; set; }

        public string ReceiverEmail { get; set; }

        public int maxUses { get; set; }

    }
}
