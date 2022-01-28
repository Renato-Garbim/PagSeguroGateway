using GatewayPagSeguro.PagSeguroDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GatewayPagSeguro.Services
{
    public class PagSeguroMyService
    {
        public PagSeguroConfig MontarObjetoConfig(Item produto, Sender dadosDoComprador)
        {
            var config = new PagSeguroConfig();

            config.Id = produto.Id;
            config.Description = produto.Description;
            config.Amount = produto.Amount;
            config.Quantity = produto.Quantity;
            config.Weight = produto.Weight;

            config.Name = dadosDoComprador.Name;
            config.Email = dadosDoComprador.Email;
            config.Phonenumber = dadosDoComprador.Phonenumber;
            config.phoneareaCode = "";

            config.addressRequired = false;
            config.Currency = "BRL";
            config.maxUses = 1;
            config.ReceiverEmail = "";

            return config;
        }

        public string MontarJson(Item produto, Sender dadosDoComprador)
        {            
            var config = new PagSeguroConfig();

            config.Id = produto.Id;
            config.Description = produto.Description;
            config.Amount = produto.Amount;
            config.Quantity = produto.Quantity;
            config.Weight = produto.Weight;

            config.Name = dadosDoComprador.Name;
            config.Email = dadosDoComprador.Email;
            config.Phonenumber = dadosDoComprador.Phonenumber;
            config.phoneareaCode = "";
            
            config.addressRequired = false;
            config.Currency = "BRL";
            config.maxUses = 1;
            config.ReceiverEmail = "";

            return JsonConvert.SerializeObject(config);
        }

        public XmlSerializer MontarXml(Item produto, Sender dadosDoComprador)
        {
            var config = new PagSeguroConfig();

            config.Id = produto.Id;
            config.Description = produto.Description;
            config.Amount = produto.Amount;
            config.Quantity = produto.Quantity;
            config.Weight = produto.Weight;

            config.Name = dadosDoComprador.Name;
            config.Email = dadosDoComprador.Email;
            config.Phonenumber = dadosDoComprador.Phonenumber;
            config.phoneareaCode = "";

            config.addressRequired = false;
            config.Currency = "BRL";
            config.maxUses = 1;
            config.ReceiverEmail = "";

            XmlSerializer x = new XmlSerializer(config.GetType());

            return x;
        }

        /// <summary>
        /// Realiza checkout com a conta parametrizada na configuração do sistema.
        /// </summary>
        /// <param name="emailUsuario">E-mail usuário pagseguro.</param>
        /// <param name="token">Token.</param>
        /// <param name="urlCheckout">URL Checkout.</param>
        /// <param name="itens">Itens de venda.</param>
        /// <param name="comprador">Dados do comprador.</param>
        /// <param name="reference">Referência da transação.</param>
        /// <returns></returns>
        public System.Collections.Specialized.NameValueCollection Checkout(Item iten, Sender comprador, string reference)
        {
            //Conjunto de parâmetros/formData.
            System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection();
            postData.Add("currency", "BRL");
            {
                postData.Add("ItemId", iten.Id);
                postData.Add("itemDescription", iten.Description);
                postData.Add("itemAmount", iten.Amount);
                postData.Add("itemQuantity", iten.Quantity);
                postData.Add("itemWeight", iten.Weight);

                //Reference.
                postData.Add("reference", reference);

                //Comprador.
                if (comprador != null)
                {
                    postData.Add("senderName", comprador.Name);
                    postData.Add("senderAreaCode", comprador.phoneareaCode);
                    postData.Add("senderPhone", comprador.Phonenumber);
                    postData.Add("senderEmail", comprador.Email);
                }

                //Shipping.
                postData.Add("shippingAddressRequired", "false");

                //Formas de pagamento.
                //Cartão de crédito e boleto.
                postData.Add("acceptPaymentMethodGroup", "CREDIT_CARD,BOLETO");


                //Retorna código do checkout.
                return postData;
            }
        }
    }
}
