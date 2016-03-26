using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
