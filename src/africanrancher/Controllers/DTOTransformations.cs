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

        public static Bovine ToBovine(this BovineDto bovineDto)
        {
            if (bovineDto.Sex == Sex.Male)
            {
                return new MaleBovine
                {
                    CastrationDate = bovineDto.CastrationDate,
                    Breed = bovineDto.Breed,
                   
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