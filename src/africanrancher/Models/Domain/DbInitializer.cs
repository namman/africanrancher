using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace africanrancher.Models.Domain
{
    public class DbInitializer
    {
        private readonly DomainDataDbContext _context;

        public DbInitializer(DomainDataDbContext context)
        {
            _context = context;
            
        }

     
    }
}
