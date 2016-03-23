using System;
using africanrancher.Models.Domain;

namespace africanrancher.Controllers
{
    public class BovineDto
    {
        
        private readonly Bovine _bovine;
        

        public BovineDto(Bovine bovine)
        {
            _bovine = bovine;
        }

        public Sex Sex
        {
            get
            {
                if (_bovine is FemaleBovine)
                {
                    return Sex.Female;
                }
                if (_bovine is MaleBovine)
                {
                    return Sex.Male;
                }
                throw new ArgumentException("Unrecognised type of bovine: " + _bovine.GetType().ToString());
            }
        }

        public string NickName => _bovine.NickName;
        public string EarTag => _bovine.EarTag;
        public string Bolus => _bovine.Bolus;

        public string Brand => _bovine.Bolus;

        public DateTimeOffset? BirthDate => _bovine.BirthDate;
        public string SireBolus => _bovine.Sire?.Bolus;
        public string DamBolus => _bovine.Dam?.Bolus;
            
        public DateTimeOffset? CastrationDate
        {
            get
            {
                var bovineAsMale = _bovine as MaleBovine;
                return bovineAsMale?.CastrationDate;
            }
        }

        public string Breed => _bovine.Breed;
        public DateTimeOffset? WeeningDate => _bovine.WeeningDate;

        public DateTimeOffset? Death => _bovine.Death;
       

    }
}