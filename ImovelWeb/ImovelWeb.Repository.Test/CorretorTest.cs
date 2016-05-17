
using ImovelWeb.DDD.Test.ValueObject.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
           Assert.IsNotNull(corretor.Email,"favor preencher o Email");
        }
 
        [TestMethod]
        [TestCategory("corrigir")]
        public void Verificar_se_contem_(){
            var msg = "erro";
            if (corretor.Email.IndexOf("@") > 0)
                msg = "ok";
           
            Assert.AreEqual("ok",msg,"Favor colocar o @");
        }
    }
}
