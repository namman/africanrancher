using System.Threading.Tasks;
using africanrancher.Models.Domain;
using Microsoft.Data.Entity;

namespace africanrancher.Controllers
{
    public static class DtoTransformations
    {
        public static BovineDto ToDto(this Bovine bovine)
        {
            return new BovineDto(bovine);
        }

        public static async Task<Bovine> CreateFromDto(this BovineDto bovineDto, DomainDataDbContext context)
        {
            FemaleBovine dam = null;
            if (bovineDto.DamBolus != null)
            {
                var damInDb = await context.FemaleBovines.SingleOrDefaultAsync(d => d.Bolus == bovineDto.DamBolus);
                if (damInDb != null)
                    dam = damInDb;
            }

            MaleBovine sire = null;
            if (bovineDto.SireBolus != null)
            {
                var sireInDb = await context.MaleBovines.SingleOrDefaultAsync(d => d.Bolus == bovineDto.SireBolus);
                if (sireInDb != null)
                    sire = sireInDb;
            }

            if (bovineDto.Sex == Sex.Male)
            {
                return new MaleBovine
                {
                    CastrationDate = bovineDto.CastrationDate,
                    Breed = bovineDto.Breed,
                    Sire = sire,
                    Dam = dam,
                    Bolus = bovineDto.Bolus,
                    BirthDate = bovineDto.BirthDate,
                    Brand = bovineDto.Brand,
                    Death = bovineDto.Death,
                    EarTag = bovineDto.EarTag,
                    WeeningDate = bovineDto.WeeningDate
                };
            }


            return new FemaleBovine
            {
                Breed = bovineDto.Breed,
                Sire = sire,
                Dam = dam,
                Bolus = bovineDto.Bolus,
                BirthDate = bovineDto.BirthDate,
                Brand = bovineDto.Brand,
                Death = bovineDto.Death,
                EarTag = bovineDto.EarTag,
                WeeningDate = bovineDto.WeeningDate
            };
        }
    }
}