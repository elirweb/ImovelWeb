
using System;
namespace ImovelWeb.DDD.Interface
{
    public interface ICorretor
    {
        bool Authenticar(String email, String senha);
    }
}
