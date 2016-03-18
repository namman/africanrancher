using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using africanrancher.Models.Domain;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace africanrancher.Controllers
{
    [Route("api/[controller]")]
    public class BovinesController : Controller
    {
        private readonly DomainDataDbContext _context;
        private readonly IBreedNameProvider _breedNameProvider;

        public BovinesController(DomainDataDbContext context, IBreedNameProvider breedNameProvider)
        {
            _context = context;
            _breedNameProvider = breedNameProvider;
            //todo: breed name provider here
        }

        [HttpGet]
        public JsonResult Get()
        {
            
                var dtos = _context.Bovines.ToList().Select(b => b.ToDto(_breedNameProvider.GetName));
                return Json(dtos);
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
