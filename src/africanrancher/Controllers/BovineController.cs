using System;
using System.Linq;
using System.Threading.Tasks;
using africanrancher.Models.Domain;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace africanrancher.Controllers
{
    
    public class BovinesController : Controller
    {
        private readonly DomainDataDbContext _context;

        public BovinesController(DomainDataDbContext context)
        {
            _context = context;


        }

        [HttpGet]
        [Route("api/Bovines")]
        public async Task<JsonResult> Get()
        {
            var bovines = await _context.Bovines.ToListAsync();
            var dtos = bovines.Select(b => b.ToDto());
            return Json(dtos);
        }

        // GET api/Bovines/5
        [HttpGet]
        [Route("api/Bovines/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bovine = await _context.Bovines.SingleOrDefaultAsync(b => b.Id == id);
            if (bovine == null)
                return HttpNotFound();
            var bovineDto = bovine.ToDto();
            return Json(bovineDto);
            
        }

        [HttpGet]
        [Route("api/Bovines/{id}/progeny")]
        public async Task<IActionResult> GetProgeny(int id)
        {
            
            var progeny = await (from p in _context.Pairings
                where (p.SireId != null && p.SireId == id || p.DamId != null && p.DamId == id)
                from b in _context.Bovines.Where(b => b.Id == p.BovineId)
                select b).ToListAsync();


            var dtosToReturn = progeny.Select(p => p.ToDto());

            return Json(dtosToReturn);



        }

        

        // POST api/values
        [HttpPost] 
        public async Task<IActionResult> Post([FromBody] BovineDto bovineDto)
        {
            var newBovineToSaveToDb = bovineDto.ToBovine();
            var asMale = newBovineToSaveToDb as MaleBovine;
            if (asMale != null)
            {
                _context.MaleBovines.Add(asMale);
            }
            else
            {
                var asFemale = newBovineToSaveToDb as FemaleBovine;
                if (asFemale != null)
                {
                    _context.FemaleBovines.Add(asFemale);
                }
            }

            _context.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BovineDto bovineDto)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}