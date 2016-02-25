using System;

namespace ImovelWeb.DDD.Test.Entidade
{
    public class State
    {
        public State(String sigla, String nome)
        {
            this.Sigla = sigla;
            this.Nome = nome;
        }

        public String Sigla { get; set; }
        public String Nome { get; set; }
    }
}

