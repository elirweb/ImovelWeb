using System.ServiceModel;

namespace ImovelWeb.WCF
{
    [ServiceContract]
    public interface IMenu
    {
        [OperationContract]
        XmlMenu PesquisarMenu(string menu);

        [OperationContract]
        void Gravar(XmlMenu m);

        [OperationContract]
        string RemoverMenu(string menu);

    }
}
