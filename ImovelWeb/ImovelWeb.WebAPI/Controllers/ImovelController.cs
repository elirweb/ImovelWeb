using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ImovelWeb.DDD.ValueObject.Model;
using ImovelWeb.Repository;

namespace ImovelWeb.WebAPI.Controllers
{
    public class ImovelController : ApiController
    {
        private readonly RepositoryImobiliario _imovel;

        public ImovelController(RepositoryImobiliario imovel_)
        {
            _imovel = imovel_;
        }
        // GET api/<controller>
        [Route("imovels/todos")]
        public IEnumerable<Imovel> Get()
        {
            return _imovel.ObterTodos(); 
        }

        // GET api/<controller>/5
        [Route("{id}/empreendimento")]
        public IQueryable<Imovel> Get(int id)
        {
            return _imovel.Localizar(x=>x.EmpreendimentoID.Equals(id));
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