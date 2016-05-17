using System.Web.Mvc;
using ImovelWeb.DDD.ValueObject.Model;
using ImovelWeb.Repository;
using ImovelWeb.WebUtil;
using System.Text;
using System;
using System.Web.Security;
namespace ImovelWeb.Startup.Controllers
{
    public class HomeController : Controller
    {
        private readonly RepositoryImobiliario _imovel;
        private readonly RepositoryUsuario _usuario;
        private readonly RepositoryVendaImovel _vendaimovel;
        // GET: Home
        public HomeController(RepositoryImobiliario imovel_,RepositoryUsuario usuario_, RepositoryVendaImovel vendaimovel_)
        {
            _imovel = imovel_;
            _usuario = usuario_;
            _vendaimovel = vendaimovel_;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginUsuario() {
            return View();
        }

        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LoginUsuario( DDD.ValueObject.Model.Usuario user_) {

            if (ModelState.IsValid)
            {
                user_.NivelUsuarioID = (int)ImovelWeb.DDD.Entidade.StatusNivelUsuario.Usuário;
                user_.Senha = WebUtil.CriptografiaSenha.CalculateSHA1(user_.Senha, Encoding.ASCII);
                _usuario.Inserir(user_);
                ViewBag.mensagem = MensagemSistema.MSG_SUCESSO;
            }
            else {
                ViewBag.mensagem = MensagemSistema.MSG_ERRO;
            }
            return Json(ViewBag.mensagem, JsonRequestBehavior.AllowGet);
        }

        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VerificarLogin(DDD.ValueObject.Model.Usuario user_) {

            if (_usuario.Authenticar(user_.Login, user_.Senha))
            {
                FormsAuthentication.SetAuthCookie(user_.Login, false);
                ViewBag.mensagem = "ok";
            }
            else
                ViewBag.mensagem = "erro";

                return Json(ViewBag.mensagem, JsonRequestBehavior.AllowGet);
    
            
        }

        public ActionResult Comprarmoveis(int? codigoimovel_) // passagens de parametro na url ? nullable
        {
            if (HttpContext.User.Identity.Name == "")
                    return RedirectToAction("LoginUsuario");
            else {
                    ViewBag.CodigoImovel = codigoimovel_;
                    ViewBag.ValorImovel = String.Format("{0:n2}", _vendaimovel.RetornarValor(codigoimovel_));
                    
                    TempData["ValorTotal"] = String.Format("{0:n2}", _vendaimovel.RetornarValor(codigoimovel_));

            } 
            return View();
        }

        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comprarmoveis(DDD.ValueObject.Model.VendaImovel vendaimovel_) {
          
           vendaimovel_.CorretorID = 1;
           vendaimovel_.TotalValor = Convert.ToDecimal(TempData["ValorTotal"].ToString().Replace(".", ""));
           vendaimovel_.UsuarioID =  _vendaimovel.CodUsuario( Convert.ToString(HttpContext.User.Identity.Name));
           vendaimovel_.Hora = DateTime.Now.ToShortTimeString(); // aumentar o campo da hora 
           var mensagem = string.Empty;
                _vendaimovel.Inserir(vendaimovel_);
                mensagem = "Compra feita com sucesso";
            
            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }
    }
}