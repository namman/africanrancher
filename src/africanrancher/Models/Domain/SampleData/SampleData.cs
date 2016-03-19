using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace africanrancher.Models.Domain.SampleData
{
    public static class SampleData
    {


        public static void AddBovines(this DomainDataDbContext context)
        {
            var sire = (MaleBovine)CreateRandomBovine(null, null,true);
            var dam = (FemaleBovine)CreateRandomBovine(null, null,false);
            var calf = CreateRandomBovine(sire, dam,false);

            context.Bovines.Add(sire);
            context.Bovines.Add(dam);
            context.Bovines.Add(calf);

        }

        static Bovine CreateRandomBovine(MaleBovine sire, FemaleBovine dam, bool isMale)
        {
            var ungendered = new Bovine()
            {
                BirthDate =
                    new DateTimeOffset(new DateTime(new Random().Next(2005,2017), new Random().Next(1, 13),
                        new Random().Next(1, 28))),
                Bolus = Guid.NewGuid().ToString(),
                Brand = Guid.NewGuid().ToString(),
                EarTag = Guid.NewGuid().ToString(),
                Breed = "East African Zebu",
                Sire = sire,
                Dam = dam

            };

            if (isMale)
                return new MaleBovine()
                {
                    BirthDate = ungendered.BirthDate,
                    Bolus = ungendered.Bolus,
                    Brand = ungendered.Brand,
                    EarTag = ungendered.EarTag,
                    Breed = ungendered.Breed,
                    Sire = ungendered.Sire,
                    Dam = ungendered.Dam
                };

            else
                return new FemaleBovine()
                {
                    BirthDate = ungendered.BirthDate,
                    Bolus = ungendered.Bolus,
                    Brand = ungendered.Brand,
                    EarTag = ungendered.EarTag,
                    Breed = ungendered.Breed,
                    Sire = ungendered.Sire,
                    Dam = ungendered.Dam
                };
        }
    }

}
