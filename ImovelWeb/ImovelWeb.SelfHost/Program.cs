using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ImovelWeb.WCF;
using System.ServiceModel.Description;


namespace ImovelWeb.SelfHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Servidor no Ar");
            // criando um Self - Host 
            // tem que subir como administrador

            var url = new Uri("http://localhost:12345/ImovelWeb/Servico");

            var servidor = new ServiceHost(typeof(Service1),url);

            servidor.AddServiceEndpoint(typeof(IMenu), new WSHttpBinding(), "");

            // HttpGetEnabled entrada de dados via get 
            servidor.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });

            servidor.Open();

            System.Console.ReadKey();
        }
    }
}
