using ImovelWeb.WebUtil;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace ImovelWeb.WorkFlow
{
    public sealed class EmailCorretorEsqueceuSenha
    {
        public bool envio = false;
        public StringBuilder mainhead = new StringBuilder();
        public string htmlbody = string.Empty;

        public bool EnviarEmailCorretor(string _email, string senha)
        {

            try
            {
                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                MailAddress remetente = new MailAddress("elirweb@gmail.com", "Portal Imovel Web");
                MailAddress destinatario = new MailAddress("elir.ribeiro@avantled.com.br", "Portal Imovel Web"); // colocar o email do cliente
                MailMessage message = new MailMessage(remetente, destinatario);

                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                message.To.Add(new MailAddress(_email, "Portal Imovel Web"));
                message.From = new MailAddress("elir45@bol.com.br", "Portal Imovel Web");
                message.Subject = "Portal Imovel Web";
                mainhead.Append("<html>");
                mainhead.Append(" <meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />  ");
                mainhead.Append(" <meta name='description' content='Portal Imovel Web' /> ");
                mainhead.Append(" <title>Portal Imovel Web</title> ");
                mainhead.Append(" <head></head> ");
                mainhead.Append(" <body > ");
                mainhead.Append(" <b>Assunto:</b> <br />");
                mainhead.Append("Senha de acesso ao portal de Imovel:" + senha);

                mainhead.Append(" </body> ");
                mainhead.Append(" </html> ");

                htmlbody = mainhead.ToString();
                AlternateView av1 = AlternateView.CreateAlternateViewFromString(htmlbody, null, MediaTypeNames.Text.Html);

                message.AlternateViews.Add(av1);


                try
                {
                    cliente.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["usuariogmail"], System.Configuration.ConfigurationManager.AppSettings["senhagmail"]);
                    cliente.EnableSsl = true;
                    envio = true;
                    cliente.Send(message);
                }
                catch (ArgumentException h)
                {

                    throw new Exception(MensagemSistema.MSG_ERRO_ENVIO_EMAIL + h.Message);
                }
                catch (Exception y)
                {
                    throw new Exception(MensagemSistema.MSG_ERRO_PROXI_EMAIL + y.Message);
                }

                envio = true;
            }
            catch (Exception)
            {

                throw;
            }

            return envio;
        }




    }
}

