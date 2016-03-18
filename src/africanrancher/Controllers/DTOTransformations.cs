using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using africanrancher.Models.Domain;

namespace africanrancher.Controllers
{
    public static class DtoTransformations
    {
        public static BovineDto ToDto(this Bovine bovine, Func<int,string> breedNameProvider)
        {
            return new BovineDto(bovine, breedNameProvider);
        }
        
    }

    public class BovineDto
    {
        private readonly Bovine _bovine;
        private readonly Func<int, string> _breedNameProvider;

        public BovineDto(Bovine bovine, Func<int, string> breedNameProvider)
        {
            _bovine = bovine;
            _breedNameProvider = breedNameProvider;
        }

        public string EarTag => _bovine.EarTag;
        public string Bolus => _bovine.Bolus;

        public string Brand => _bovine.Bolus;

        public DateTimeOffset? BirthDate => _bovine.BirthDate;
        public string SireBolus => _bovine.Sire?.Bolus;
        public string DamBolus => _bovine.Dam?.Bolus;

        public string Breed => _bovine.Breed != null ? _breedNameProvider(_bovine.Breed.Value) : "Unknown";
        public DateTimeOffset? WeeningDate => _bovine.WeeningDate;

        public DateTimeOffset? Death => _bovine.Death;
       

    }
}
