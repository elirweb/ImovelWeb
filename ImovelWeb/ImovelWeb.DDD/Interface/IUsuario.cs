
using System;
namespace ImovelWeb.DDD.Interface
{
    public interface IUsuario
    {
        bool Authenticar(String login, String senha);
    }
}
