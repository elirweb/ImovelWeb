using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ImovelWeb.WCF
{
    [DataContract]
    public class XmlMenu
    {
        [Obsolete]
        public int ID;

        [DataMember(Order = 2)]
        public string Nome;

        [DataMember(Order = 3)]
        public string Linq;

    }
}