
using System.ServiceModel;
namespace ImovelWeb.WCF
{
    [ServiceContract]
    interface IMenu
    {

        [OperationContract]
        XmlMenu PesquisarMenu(string menu);

        [OperationContract]
        void Gravar(XmlMenu m);

        [OperationContract]
        string RemoverMenu(string menu);
    }
}
