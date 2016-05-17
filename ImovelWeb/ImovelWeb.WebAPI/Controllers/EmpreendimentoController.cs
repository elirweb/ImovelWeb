using ImovelWeb.DDD.ValueObject.Model;
using ImovelWeb.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ImovelWeb.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET")] // definindo o cabecalho de origens para receber metodo get 
   
    public class EmpreendimentoController : ApiController
    {
        // GET api/<controller>
        private readonly RepositoryEmpreendimento _empreendimento;
        public EmpreendimentoController(RepositoryEmpreendimento empreendimento_)
        {
            _empreendimento = empreendimento_;
            
            
        }

        [Route("empreendimento/todos")]
        public IEnumerable<Empreendimento> Get()
        {

            return _empreendimento.ObterTodos();
        }

        // GET api/<controller>/5
        [Route("{valor}/buscar")]
        public IQueryable<Empreendimento> Get(string  valor)
        {
            var detalhes = _empreendimento.Localizar(x=>x.Nome.Contains(valor));
            return detalhes;
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