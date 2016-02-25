using ImovelWeb.Repository;
using System;
namespace ImodelWeb.Console
{
    
    public class Program
    {
        static void Main(string[] args)
        {
             string sair = string.Empty;
             string escolha = string.Empty;
             string nivelusuario = string.Empty;
             string dados = string.Empty;
             System.Console.WriteLine("Tela do Adminsitrador do Sistema\n");
             
            do{
                System.Console.WriteLine("1 - Cadastrar Nivel de Usuário\n");
                System.Console.WriteLine("2 - Cadastrar Linq do Sistema\n");
                System.Console.WriteLine("3 - Relatorios de Corretores\n");
                System.Console.WriteLine("4 - Relatorios de Empreendimento\n");
                System.Console.WriteLine("5 - Relatorios de Imovel\n");
                System.Console.WriteLine("6 - Relatorios de Imovel Vendidos\n");
                System.Console.WriteLine("7 - Suporte Remoto\n");
                System.Console.WriteLine("10 - Sair do sistema\n");


                System.Console.WriteLine("O que deseja fazer?\n");
                escolha = Convert.ToString(System.Console.ReadLine());

               
                switch (escolha)
                {
                    case "1":
                        System.Console.WriteLine(ImovelWeb.DDD.Entidade.StatusNivelUsuario.Administrador + "\n" + ImovelWeb.DDD.Entidade.StatusNivelUsuario.Corretor + "\n" + ImovelWeb.DDD.Entidade.StatusNivelUsuario.Usuário + "\n");
                        dados = Convert.ToString(System.Console.ReadLine());
                        ImovelWeb.DDD.ValueObject.Model.NivelUsuario nivel;
                        var comit = false;
                        nivel = new ImovelWeb.DDD.ValueObject.Model.NivelUsuario
                        {
                            Perfil = dados
                        };

                        using (RepositoryNivelUsuario cadastrar = new RepositoryNivelUsuario())
                        {
                            cadastrar.Inserir(nivel);
                            comit = true;
                        }
                        if (comit)
                            System.Console.WriteLine("Cadastro efetuado com Sucesso\n");
                            break;
                    case "5":
                        ImovelWeb.Console.Funcoes.ConsultaCorretores.ListCorretorAsync("http://localhost:51744/api/corretor/");
                      
                        break;

                    case "10":
                        System.Console.WriteLine("Deseja sair do sistema? S(Sair) C(continuar)\n");
                        sair = System.Console.ReadLine();
         
                        break;
                    default:
                        break;
                }



            } while (sair == "s" || sair == "S");

            System.Console.ReadKey();
            
        }

        
        
    }
}
