using ImovelWeb.DDD.ValueObject.Model;
using ImovelWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ImovelWeb.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET")] // definindo o cabecalho de origens para receber metodo get 
   
   
    public class CorretorController : ApiController
    {
        private readonly RepositoryCorretor corretor = new RepositoryCorretor();
        // GET api/<controller>
        public IEnumerable<Corretor> Get()
        {
            return corretor.ObterTodos();
        }

        // GET <!--http://localhost:51744/api/corretor/?valor=elir45@bol.com.br parametro -->
        public IQueryable<Corretor> Get(string valor)
        {
            var emailcorretor = corretor.Localizar(x => x.Email.Equals(valor.Trim()));
            return emailcorretor;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


    }
}