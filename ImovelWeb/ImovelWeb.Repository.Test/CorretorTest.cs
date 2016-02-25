
using ImovelWeb.DDD.Test.ValueObject.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
namespace ImovelWeb.Repository.Test
{
    
    [TestClass]
    public class CorretorTest
    {
        private ICorretorRepositoryTest MoqCorretor { get; set; } 
        
        public CorretorTest()
        {
            List<Corretor> corretor = 
                new List<Corretor> {
                new Corretor { CorretorID = 1, Matricula = "123456", Email = "elirweb@gmail.com", Cidade = "São Paulo",
                Estado = "SP", Endereco = "Silveira Pires", NomeCorretor = "Emanuel", NivelUsuarioID = 2, Login  = "elirweb", Senha = "123456", Sexo = "M", 
                Telefone = "123456"  }
            };


            // retornando lista de corretor cadastrado no banco de dados
            var mockcorretor = new Mock<ICorretorRepositoryTest>();
            mockcorretor.Setup(c=>c.Corretor).Returns(corretor);

        }

        [TestMethod]
        public void Verificar_Campo_Email_Em_Branco() {
           IList<Corretor> campos = this.MoqCorretor.Corretor;
            
             //Assert.IsNotNull(campos.); // testando se tá nulo
            Assert.AreEqual(0, campos.Count); // comprando o n. de itens
        }

        
    }
}
