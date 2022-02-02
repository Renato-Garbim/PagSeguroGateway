using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GatewayPagSeguro.Services
{
    public class GeradorService
    {
        public string GerarXML<TEntity>(TEntity objeto) where TEntity : class
        {
            XmlSerializer x = new XmlSerializer(objeto.GetType());
            StringWriter sw = new StringWriter();
                       
            x.Serialize(sw, objeto);

            return sw.ToString();

        }        
    }
}
