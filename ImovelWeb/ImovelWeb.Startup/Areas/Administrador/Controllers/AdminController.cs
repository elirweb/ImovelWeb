using ImovelWeb.DDD.ValueObject.Model;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ImovelWeb.Repository;
using ImovelWeb.WorkFlow;
using ImovelWeb.WebUtil;
using System.Text;
using System.Data.Entity.Core;
using System;
namespace ImovelWeb.Startup.Areas.Administrador.Controllers
{
   
    public class AdminController : Controller
    {

        private readonly RepositoryCorretor _corretor;
        private readonly EmailCorretor _emailcorretor;
        private readonly RepositoryRegistro _registro;
        private readonly RepositoryEmpreendimento _empreendimento;
        private readonly EmailCorretorEsqueceuSenha _emailcorretoresqueceu;
        private readonly RepositorioFoto _foto;
        private readonly RepositoryPorcentagem _porcentagem;

        
        // COMEÇANDO O IOC
        public AdminController(RepositoryCorretor corretor_,EmailCorretor emailcorretor_,
            RepositoryRegistro registro_,RepositoryEmpreendimento empreendimento_, 
            EmailCorretorEsqueceuSenha emailcorretoresqueceu_, RepositorioFoto foto_, RepositoryPorcentagem porcentagem_)
        {
            _corretor = corretor_;
            _emailcorretor = emailcorretor_;
            _registro = registro_;
            _empreendimento = empreendimento_;
            _emailcorretoresqueceu = emailcorretoresqueceu_;
            _foto = foto_;
            _porcentagem = porcentagem_;

        }

        // GET: Administrador/Admin
        public ActionResult Index()
        {
            
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DDD.ValueObject.Model.Usuario model)
        {
            if (_corretor.Authenticar(model.Login, CriptografiaSenha.CalculateSHA1(model.Senha, Encoding.ASCII)))
            { 
                 
                FormsAuthentication.SetAuthCookie(model.Login, false);
                return RedirectToAction("/Home");

            }
            else
            {
                ViewBag.mensagem = MensagemSistema.MSG_ERRO_SENHA_USUARIO;
                return View();
            }
            
        }

        public static void Deslogar() {

            FormsAuthentication.SignOut();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Cadcorretor( ImovelWeb.DDD.ValueObject.Model.Corretor corretor)
        {
            var msg = "";
            var comitar = false;
            if (ModelState.IsValid)
            {
                try
                {

                    corretor.Senha = CriptografiaSenha.CalculateSHA1(corretor.Senha, Encoding.ASCII);
                    _corretor.Inserir(corretor);
                    _emailcorretor.EnviarEmailCorretor(corretor.Email);

                    // inserir novo registro
                    _registro.NovoCorretor(corretor);

                    comitar = true;
                }
                catch (EntitySqlException f) {

                    throw new Exception("Erro" + f.Message);
                }
            }

            if (comitar)
                msg = MensagemSistema.MSG_SUCESSO;
            else
                msg = MensagemSistema.MSG_ERRO;
    
            return Json(msg, JsonRequestBehavior.AllowGet);


        }
        
        [Authorize]
        public ActionResult Home() {
            
            return View();
        }
        [Authorize]
        public ActionResult Foto() {
            
            
            ViewData["EmpreendimentoID"] = new SelectList(_empreendimento.ObterTodos(), "EmpreendimentoID", "Nome");
         
            return View();
        }



        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Foto(HttpPostedFileBase file,Foto foto)
        {
            if (ModelState.IsValid) {
                _foto.Inserir(foto);
                _foto.Foto(file, foto.NomeFoto);
                ViewBag.msg = MensagemSistema.MSG_SUCESSO;
                
            }
            
            ViewData["EmpreendimentoID"] = new SelectList(_empreendimento.ObterTodos(), "EmpreendimentoID", "Nome");
         
            return View();
        }

        
        [Authorize]
        public ActionResult Imovel() {
            ViewData["EmpreendimentoID"] = new SelectList(_empreendimento.ObterTodos(), "EmpreendimentoID", "Nome");
         
            ViewData["PorcentagemID"] = new SelectList(_porcentagem.ObterTodos(), "PorcentagemID", "Desconto");
            return View();
        }
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Imovel(Imovel imovel) {

            return Json(new { ok = "enviado com sucesso" }, JsonRequestBehavior.AllowGet);
        }

        
        [Authorize]
        public ActionResult Empreendimento() {

            var  idcorretor =  _corretor.Localizar(c => c.Email.Equals(User.Identity.Name));
            foreach(var item in idcorretor){
                ViewBag.IDCorretor = item.CorretorID;
            }

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Empreendimento(Empreendimento model) {
            var msg = "";
            if (ModelState.IsValid) {
                _empreendimento.Inserir(model);
                msg = MensagemSistema.MSG_SUCESSO;
            }
            


            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        public ActionResult Porcentagem() {
            return View();
        }

        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Porcentagem(Porcentagem porcentagem)
        {
            var msg = "";
            if (ModelState.IsValid) {
               
                    var proc = _porcentagem.Localizar(x => x.Desconto.Equals(porcentagem));
                    if (proc != null)
                        msg = MensagemSistema.MSG_DESCONTO_CADASTRADO;
                    else
                    {
                        _porcentagem.Inserir(porcentagem);
                        msg = MensagemSistema.MSG_SUCESSO;
                    }
                
            }
            return Json(msg,JsonRequestBehavior.AllowGet);
        }

        

        public ActionResult EsqueceuEmail(string email,string senha) {
            _emailcorretoresqueceu.EnviarEmailCorretor(email, senha);        
            return RedirectToAction("Index");
        }
    }
}

    
