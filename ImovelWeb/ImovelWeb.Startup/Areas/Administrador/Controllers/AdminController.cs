using ImovelWeb.DDD.ValueObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            using (RepositoryImovel.RepositoryCorretor corretor = new RepositoryImovel.RepositoryCorretor()) {

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
                using (RepositoryImovel.RepositoryCorretor scorretor = new RepositoryImovel.RepositoryCorretor()) {
                    scorretor.Inserir(corretor);
                    //sendecorretor.EnviarEmailCorretor(corretor.Email);
                    RepositoryImovel.RepositoryRegistro registro = new RepositoryImovel.RepositoryRegistro();

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
            
            
            RepositoryImovel.RepositoryEmpreendimento emp = new RepositoryImovel.RepositoryEmpreendimento();
            ViewData["EmpreendimentoID"] = new SelectList(emp.ObterTodos(), "EmpreendimentoID", "Nome");
         
            return View();
        }



        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Foto(HttpPostedFileBase file,Foto foto)
        {
            var msg = "";
            if (ModelState.IsValid) {
                using (RepositoryImovel.RepositorioFoto fot = new RepositoryImovel.RepositorioFoto()) {
                    fot.Inserir(foto);
                    fot.Foto(file, foto.NomeFoto);
                    ViewBag.msg = "Dados cadastrados com sucesso";
                    
                }
            }
            
            RepositoryImovel.RepositoryEmpreendimento emp = new RepositoryImovel.RepositoryEmpreendimento();
            ViewData["EmpreendimentoID"] = new SelectList(emp.ObterTodos(), "EmpreendimentoID", "Nome");
         
            return View();
        }

        
        [Authorize]
        public ActionResult Imovel() {
            RepositoryImovel.RepositoryEmpreendimento emp = new RepositoryImovel.RepositoryEmpreendimento();
            ViewData["EmpreendimentoID"] = new SelectList(emp.ObterTodos(), "EmpreendimentoID", "Nome");
         
            RepositoryImovel.RepositoryPorcentagem porc = new RepositoryImovel.RepositoryPorcentagem();
            ViewData["PorcentagemID"] = new SelectList(porc.ObterTodos(), "PorcentagemID", "Desconto");
            return View();
        }
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Imovel(Imovel imovel) {
            var msg = "";
            if (ModelState.IsValid) {
                using (RepositoryImovel.RepositoryImobiliario imo = new RepositoryImovel.RepositoryImobiliario()) {
                    imo.Inserir(imovel);
                    msg = "Cadastrado com sucesso";
                }
            }


            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        
        [Authorize]
        public ActionResult Empreendimento() {

            RepositoryImovel.RepositoryCorretor corretor = new RepositoryImovel.RepositoryCorretor();
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

                using (RepositoryImovel.RepositoryEmpreendimento empreendimento = new RepositoryImovel.RepositoryEmpreendimento()) {
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
                using (RepositoryImovel.RepositoryPorcentagem porc = new RepositoryImovel.RepositoryPorcentagem())
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

    
