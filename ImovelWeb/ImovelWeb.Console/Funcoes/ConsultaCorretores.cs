using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace ImovelWeb.Console.Funcoes
{
    public class ConsultaCorretores
    {
        public  static void ListCorretorAsync(string endereco)
        {

            HttpClient client = null;
            Uri usuarioUri;


            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(endereco);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }

            //chamando a api pela url (método que deve ser requisitado para retorno desejado)
            HttpResponseMessage response = client.GetAsync("corretor/todos").Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //pegando o cabeçalho
                usuarioUri = response.Headers.Location;

                //Pegando os dados do Rest e armazenando na variável usuários
                string Retorno = response.Content.ReadAsStringAsync().Result;

                //preenchendo a lista com os dados retornados da variável
                System.Console.WriteLine(Retorno);
                System.Console.ReadLine();
            }

            //Se der erro na chamada, mostra o status do código de erro.
            else
                System.Console.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                System.Console.ReadLine();
        

        }
    }
}

