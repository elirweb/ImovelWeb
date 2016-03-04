
using ImovelWeb.DDD.Interface;
using ImovelWeb.DDD.ValueObject.Model;
using System;
namespace ImovelWeb.Repository
{
    public class RepositoryRegistro:RepositoryBase<Registro>,IRegistro
    {
        public RepositoryRegistro() : base(new DDD.ValueObject.Model.ImovelWeb()) { }


        public void NovoCorretor(Corretor novo)
        {
            RepositoryRegistro reg = new RepositoryRegistro();
            Registro dados = new Registro()
            {
                CorretorID = novo.CorretorID,
                DataCriacao = DateTime.Today,
                Status = true
            };
            reg.Inserir(dados);

        }


    }
}
