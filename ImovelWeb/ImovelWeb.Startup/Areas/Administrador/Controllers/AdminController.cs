using ImovelWeb.DDD.ValueObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ImovelWeb.Repository;
using ImovelWeb.WorkFlow;
namespace ImovelWeb.Startup.Areas.Administrador.Controllers
{
    public class AdminController : Controller
    {
        // GET: Administrador/Admin
       public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection model)
        {
            using (RepositoryCorretor corretor = new RepositoryCorretor()) {

                if (corretor.Authenticar(model["Login"], model["Senha"]))
                {
                    FormsAuthentication.SetAuthCookie(model["Login"], false);
                    return RedirectToAction("/Home");
                }
                else
                {
                    ViewBag.mensagem = "Usuario ou Senha não confere";
                    return View();
                }
            }
            
            
        }

        public static void Deslogar() {

            FormsAuthentication.SignOut();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Cadcorretor( ImovelWeb.DDD.ValueObject.Model.Corretor corretor)
        {
            var msg = string.Empty;
            var comitar = false;
            EmailCorretor sendecorretor = new EmailCorretor();
            if (ModelState.IsValid)
            {
                using (RepositoryCorretor scorretor = new RepositoryCorretor()) {
                    scorretor.Inserir(corretor);
                    //sendecorretor.EnviarEmailCorretor(corretor.Email);
                    RepositoryRegistro registro = new RepositoryRegistro();

                    // inserir novo registro
                    registro.NovoCorretor(corretor);
                    
            };
            
            comitar = true;

        }

        if (comitar)
            msg = "Cadastro efetuado com sucesso";
        else
            msg = "Erro! no cadastro";
    
            return Json(msg, JsonRequestBehavior.AllowGet);


        }
        
        [Authorize]
        public ActionResult Home() {
            
            return View();
        }
        [Authorize]
        public ActionResult Foto() {
            
            
            RepositoryEmpreendimento emp = new RepositoryEmpreendimento();
            ViewData["EmpreendimentoID"] = new SelectList(emp.ObterTodos(), "EmpreendimentoID", "Nome");
         
            return View();
        }



        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Foto(HttpPostedFileBase file,Foto foto)
        {
           // var msg = "";
            if (ModelState.IsValid) {
                using (RepositorioFoto fot = new RepositorioFoto()) {
                    fot.Inserir(foto);
                    fot.Foto(file, foto.NomeFoto);
                    ViewBag.msg = "Dados cadastrados com sucesso";
                    
                }
            }
            
            RepositoryEmpreendimento emp = new RepositoryEmpreendimento();
            ViewData["EmpreendimentoID"] = new SelectList(emp.ObterTodos(), "EmpreendimentoID", "Nome");
         
            return View();
        }

        
        [Authorize]
        public ActionResult Imovel() {
            RepositoryEmpreendimento emp = new RepositoryEmpreendimento();
            ViewData["EmpreendimentoID"] = new SelectList(emp.ObterTodos(), "EmpreendimentoID", "Nome");
         
            RepositoryPorcentagem porc = new RepositoryPorcentagem();
            ViewData["PorcentagemID"] = new SelectList(porc.ObterTodos(), "PorcentagemID", "Desconto");
            return View();
        }
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Imovel(Imovel imovel) {
            var msg = "";
            if (ModelState.IsValid) {
                using (RepositoryImobiliario imo = new RepositoryImobiliario()) {
                    //imo.Inserir(imovel);
                    msg = "Cadastrado com sucesso";
                }
            }


            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        
        [Authorize]
        public ActionResult Empreendimento() {

            RepositoryCorretor corretor = new RepositoryCorretor();
            var  idcorretor =  corretor.Localizar(c => c.Email.Equals(User.Identity.Name));
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

                using (RepositoryEmpreendimento empreendimento = new RepositoryEmpreendimento()) {
                    empreendimento.Inserir(model);
                    msg = "Cadastrado com sucesso";
                }
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
                using (RepositoryPorcentagem porc = new RepositoryPorcentagem())
                {
                    var proc = porc.Localizar(x => x.Desconto.Equals(porcentagem));
                    if (proc != null)
                    {
                        msg = "Desconto cadastrado no sistema";
                    }
                    else
                    {
                        porc.Inserir(porcentagem);
                        msg = "Porcentagem inserido com sucesso";
                    }
                }
            }
            return Json(msg,JsonRequestBehavior.AllowGet);
        }

        public ActionResult EsqueceuEmail(string email,string senha) {
            EmailCorretorEsqueceuSenha sendecorretor = new EmailCorretorEsqueceuSenha();
            sendecorretor.EnviarEmailCorretor(email,senha);        
            return RedirectToAction("Index");
        }
    }
}

    
