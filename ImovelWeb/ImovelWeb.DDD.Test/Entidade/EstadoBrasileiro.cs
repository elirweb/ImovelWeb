
using System.Collections.Generic;
using System.Linq;
namespace ImovelWeb.DDD.Test.Entidade
{
    public class EstadoBrasileiro
    {
        public static IList<State> Estado()
        {
            List<State> uf = new List<State>();
            uf.Add(new State("Go", "Goias"));
            uf.Add(new State("MT", "Mato Grosso"));
            uf.Add(new State("MS", "Mato Grosso do Sul"));
            uf.Add(new State("DF", "Distrito Federal"));
            uf.Add(new State("AM", "Amazonas"));
            uf.Add(new State("AC", "Acre"));
            uf.Add(new State("RO", "Rondônia"));
            uf.Add(new State("RR", "Roraima"));
            uf.Add(new State("AP", "Amapá"));
            uf.Add(new State("TO", "Tocantins"));
            uf.Add(new State("PA", "Para"));
            uf.Add(new State("MA", "Maranhão"));
            uf.Add(new State("PI", "Piaui"));
            uf.Add(new State("CE", "Ceara"));
            uf.Add(new State("RN", "Rio Grande do Norte"));
            uf.Add(new State("PB", "Paraiba"));
            uf.Add(new State("PE", "Pernambuco"));
            uf.Add(new State("SE", "Sergipe"));
            uf.Add(new State("AL", "Alagoas"));
            uf.Add(new State("BA", "Bahia"));
            uf.Add(new State("SP", "São Paulo"));
            uf.Add(new State("MG", "Minas Gerais"));
            uf.Add(new State("RJ", "Rio de Janeiro"));
            uf.Add(new State("ES", "Espirito Santo"));
            uf.Add(new State("PR", "Parana"));
            uf.Add(new State("SC", "Santa Catarina"));
            uf.Add(new State("RS", "Rio Grande do Sul"));
            return uf.OrderBy(x => x.Sigla).ToList(); // ordernando elemento ordem crescente
        }
    }
}