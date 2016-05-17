using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImovelWeb.Repository
{
    public class RepositoryImobiliario:RepositoryBase<Imovel>,ImovelInterface
    {
        public RepositoryImobiliario() : base(new DDD.ValueObject.Model.ImovelWeb()) { }



        public float FormatarPreco(string preco)
        {
             float novovalor;
             string ponto_add = string.Empty;
            switch (preco.Length) { 

                case 5: 
                    ponto_add = preco.Substring(3, 2);
                    preco = preco.Substring(0,3) + "." + ponto_add;
                    novovalor = float.Parse(String.Format("{0:n2}", decimal.Round(decimal.Parse(preco.ToString().Replace(".", ",")), 2)));
                    break;
                case 6:
                    ponto_add = preco.Substring(4, 2);
                    preco = preco.Substring(0,4) + "." + ponto_add;
                    novovalor = float.Parse(String.Format("{0:n2}", decimal.Round(decimal.Parse(preco.ToString().Replace(".", ",")), 2)));
                    break;
                case 7:
                    ponto_add = preco.Substring(5, 2);
                    preco = preco.Substring(0, 5) + "." + ponto_add;
                    novovalor = float.Parse(String.Format("{0:n2}", decimal.Round(decimal.Parse(preco.ToString().Replace(".", ",")), 2)));
                    break;
                case 8:
                    ponto_add = preco.Substring(6, 2);
                    preco = preco.Substring(0, 6) + "." + ponto_add;
                    novovalor = float.Parse(String.Format("{0:n2}", decimal.Round(decimal.Parse(preco.ToString().Replace(".", ",")), 2)));
                    break;
                default:
                    novovalor = 0;
                    break;
            }
           
            return novovalor;  
        }
    }
}
