using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using africanrancher.Models.Domain;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace africanrancher.Controllers
{
    public class OfficeController : Controller
    {
        private readonly DomainDataDbContext _context;

        public OfficeController(DomainDataDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("office/cattle/{bovineId}")]
        public async Task<IActionResult> Edit(int bovineId)
        {
            var bovine = await _context.Bovines.SingleOrDefaultAsync(b => b.Id == bovineId);
            if (bovine == null)
                return HttpNotFound();

            return View(bovine);

        }
    


    }
}
