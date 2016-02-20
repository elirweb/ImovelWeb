using System;
using System.Runtime.Serialization;

namespace ImovelWeb.WCF
{
    [DataContract]
    public class XmlMenu
    {
        [Obsolete]
        public Int32 Idmenu;

        [DataMember(Order = 2)]
        public String Nome;

        [DataMember(Order = 3)]
        public String Linq;
    }
}
