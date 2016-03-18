using System;
using System.Collections.Generic;
using System.Linq;
using africanrancher.Models.Domain;

namespace africanrancher.Controllers
{
    public class BreedNameFromDbProvider : IBreedNameProvider
    {
        private readonly DomainDataDbContext _context;
        private Dictionary<int, string> _breeds;

        public BreedNameFromDbProvider(DomainDataDbContext context)
        {
            _context = context;
            _breeds = _context.Breeds.ToList().ToDictionary(b => b.Id, b => b.Name);

        }

        public string GetName(int number)
        {
            if (_breeds.ContainsKey(number))
            {
                return _breeds[number];
            }
            throw new ArgumentException($"Could not find breed for this ID in database: {number}.");
        }
    }
}