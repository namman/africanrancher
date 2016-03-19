using System.Linq;
using System.Threading.Tasks;
using africanrancher.Models.Domain;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace africanrancher.Controllers
{
    [Route("api/[controller]")]
    public class BovinesController : Controller
    {
        private readonly DomainDataDbContext _context;

        public BovinesController(DomainDataDbContext context)
        {
            _context = context;


        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var bovines = await _context.Bovines.ToListAsync();
            var dtos = bovines.Select(b => b.ToDto());
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
        public async Task<IActionResult> Post([FromBody] BovineDto bovineDto)
        {
            var newBovineToSaveToDb = await bovineDto.CreateFromDto(_context);
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