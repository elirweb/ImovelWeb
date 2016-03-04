using ImovelWeb.WebUtil;
using System;
using System.Data;
using System.IO;
using System.Xml;

namespace ImovelWeb.WCF
{
    public class ServicoMenu:IMenu
    {
        private String _nomearquivo = string.Empty;

        public XmlMenu PesquisarMenu(string menu)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            XmlMenu item = new XmlMenu();
            ds.ReadXml(System.Configuration.ConfigurationManager.AppSettings["CaminhoXMLArquivoFinal"]);
            dt = ds.Tables["Menu"];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    if (rw["Nome"].ToString() == menu)
                    {
                        item.Nome = rw["Nome"].ToString();
                        item.Linq = rw["Link"].ToString();
                        break;
                    }
                    else
                    {
                        item.Nome = MensagemSistema.MSG_MENU_NAO_CADASTRADO;


                    }
                }
            }
            return item;

        }

        public void Gravar(XmlMenu menu)
        {
            var diretorio = System.Configuration.ConfigurationManager.AppSettings["CaminhoXML"];
            _nomearquivo = "menu.xml";
            var doc = new XmlDocument();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow rw = dt.NewRow();

            ds.DataSetName = "Links";
            dt.TableName = "Menu";
            dt.Columns.Add("Id");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Link");
            ds.Tables.Add(dt);

            if (Directory.Exists(diretorio))
            {
                ds.ReadXml(System.Configuration.ConfigurationManager.AppSettings["CaminhoXMLArquivoFinal"]);
                rw["Id"] = Guid.NewGuid();
                rw["Nome"] = menu.Nome;
                rw["Link"] = menu.Linq;
                dt.Rows.Add(rw);

            }
            else
            {
                Directory.CreateDirectory(diretorio);

                rw["Id"] = Guid.NewGuid();
                rw["Nome"] = menu.Nome;
                rw["Link"] = menu.Linq;

                dt.Rows.Add(rw);
            }
            ds.WriteXml(diretorio + _nomearquivo);

        }

        public string RemoverMenu(string menu)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            XmlMenu item = new XmlMenu();
            ds.ReadXml(System.Configuration.ConfigurationManager.AppSettings["CaminhoXMLArquivoFinal"]);
            dt = ds.Tables["Menu"];

            bool resultado = false;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    if (rw["Nome"].ToString() == menu)
                    {
                        dt.Rows.Remove(rw);
                        resultado = true;
                        ds.WriteXml(System.Configuration.ConfigurationManager.AppSettings["CaminhoXMLArquivoFinal"]); //salvar dentro do xml 
                        break;
                    }
                    else
                    {
                        resultado = false;
                    }
                }
            }
            if (resultado)
                return MensagemSistema.MSG_MENU_REMOVIDO;
            else
                return MensagemSistema.MSG_MENU_NAO_CADASTRADO;

        }
    }
}
