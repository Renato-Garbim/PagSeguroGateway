using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GatewayPagSeguro.DTO
{
    public class PagSeguroCompradorDTO
    {

        [DisplayName("Nome")]
        public string SenderName { get; set; }

        [DisplayName("CEP")]
        public string SenderAreaCode { get; set; }

        [DisplayName("Telefone")]
        public string senderPhone { get; set; }

        [DisplayName("Email")]
        public string senderEmail { get; set; }
    }
}