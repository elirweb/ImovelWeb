using ImovelWeb.DDD.ValueObject.Model;
using ImovelWeb.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;


namespace ImovelWeb.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET")] // definindo o cabecalho de origens para receber metodo get 
   
   
    public class CorretorController : ApiController
    {

        private readonly RepositoryCorretor _corretor;

        public CorretorController(RepositoryCorretor corretor_)
        {
            _corretor = corretor_;
        }

        // GET api/<controller>
        [Route("corretor/todos")]
        public IEnumerable<Corretor> Get()
        {
            

            return _corretor.ObterTodos();
        }
        // GET <!--http://localhost:50642/api/corretor/?valor=elir45@bol.com.br parametro  route http://localhost:50642/elirweb@gmail.com/email -->
        [Route("{valor}/email")]
        public IQueryable<Corretor> Get(string valor)
        {
            var emailcorretor = _corretor.Localizar(x => x.Email.Equals(valor.Trim()));
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