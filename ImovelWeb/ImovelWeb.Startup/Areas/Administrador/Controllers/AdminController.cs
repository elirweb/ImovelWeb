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
        private readonly RepositoryImobiliario _imovel;

        
        // COMEÇANDO O IOC
        public AdminController(RepositoryCorretor corretor_,EmailCorretor emailcorretor_,
            RepositoryRegistro registro_,RepositoryEmpreendimento empreendimento_, 
            EmailCorretorEsqueceuSenha emailcorretoresqueceu_, RepositorioFoto foto_, RepositoryPorcentagem porcentagem_,
            RepositoryImobiliario imovel_)
        {
            _corretor = corretor_;
            _emailcorretor = emailcorretor_;
            _registro = registro_;
            _empreendimento = empreendimento_;
            _emailcorretoresqueceu = emailcorretoresqueceu_;
            _foto = foto_;
            _porcentagem = porcentagem_;
            _imovel = imovel_;

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

        public ActionResult  Deslogar() {

            FormsAuthentication.SignOut();
            return RedirectToAction("/Index");
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
            if (ModelState.IsValid)
            {
                _foto.ArquivarFoto(file, foto.NomeFoto);
                _foto.Inserir(foto);
                ViewBag.msg = MensagemSistema.MSG_SUCESSO;
            }
            else
                ViewBag.msg = MensagemSistema.MSG_ERRO;
            
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

            imovel.Preco = Convert.ToDecimal( _imovel.FormatarPreco(Convert.ToString(imovel.Preco)));

            if (ModelState.IsValid)
            {
                _imovel.Inserir(imovel);
                ViewBag.mensagem = MensagemSistema.MSG_SUCESSO;
            }
            else {
                ViewBag.mensagem = MensagemSistema.MSG_ERRO;
            }

            ViewData["EmpreendimentoID"] = new SelectList(_empreendimento.ObterTodos(), "EmpreendimentoID", "Nome");

            ViewData["PorcentagemID"] = new SelectList(_porcentagem.ObterTodos(), "PorcentagemID", "Desconto");

            return Json(ViewBag.mensagem, JsonRequestBehavior.AllowGet);
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

            if (ModelState.IsValid)
            {
                _empreendimento.Inserir(model);
                ViewBag.mensagem = MensagemSistema.MSG_SUCESSO;
            }
            else {
                ViewBag.mensagem = MensagemSistema.MSG_ERRO;
            }
            
            return Json(ViewBag.mensagem,JsonRequestBehavior.AllowGet);
                
        }


        [Authorize]
        public ActionResult Porcentagem() {
            return View();
        }

        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Porcentagem(Porcentagem porcentagem)
        {
            if (ModelState.IsValid) {
               
                _porcentagem.Inserir(porcentagem);
                ViewBag.mensagem = MensagemSistema.MSG_SUCESSO;
                
            }
            return Json(ViewBag.mensagem, JsonRequestBehavior.AllowGet);
        }

        

        public ActionResult EsqueceuEmail(string email,string senha) {
            // sem internet
            //_emailcorretoresqueceu.EnviarEmailCorretor(email, senha);        
            return RedirectToAction("Index");
        }
    }
}

    
