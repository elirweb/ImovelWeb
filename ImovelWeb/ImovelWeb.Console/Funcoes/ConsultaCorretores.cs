using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace ImovelWeb.Console.Funcoes
{
    public class ConsultaCorretores
    {
        public async static void ListCorretorAsync(string endereco)
        {

            var cliente = new HttpClient()
            {
                BaseAddress = new Uri(endereco)
            };

            HttpResponseMessage message = await cliente.GetAsync("corretor");
            var res = message.Content.ReadAsStringAsync();
            JArray dados = JArray.Parse(res.Result);
            string propriedades = string.Empty;
            foreach (JObject obj in dados.Children<JObject>())
            {
                foreach (JProperty prop in obj.Properties())
                {
                    if (prop.HasValues)
                        if (!prop.Value.ToString().Contains("[]"))
                        {
                            propriedades += prop.Name.ToString() + " : " + prop.Value.ToString() + "\n\n";
                        }
                }
            }

            System.Console.WriteLine(propriedades);
        }
    }
}

