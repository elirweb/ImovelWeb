
using ImovelWeb.DDD.Test.Interface;
using ImovelWeb.DDD.Test.ValueObject.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
namespace ImovelWeb.Repository.Test
{
    
    [TestClass]
    public class CorretorTest
    {

        Corretor corretor;

        public CorretorTest()
        {
            corretor = new Corretor()
            {

                Login = "elir",
                NomeCorretor = "Elir de Assis Ribeiro",
                Matricula = "1245",
                Senha = "123456",
                Sexo = "M",
                Telefone = "123456",
                Cidade = "São Paulo",
                Email = "elirweb@gmail.com",
                Estado = "SP",
                CorretorID = 43,
                Endereco = "Silveira pires",
                NivelUsuarioID = 1
            };
        }

       
        [TestMethod]
        [TestCategory("Inicializacao de categoria")]
        public void Verficar_Nome_Em_Branco() {
           Assert.AreEqual("", corretor.Email);
        } 
        
    }
}
