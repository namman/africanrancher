using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace africanrancher.Models.Domain.SampleData
{
    public static class SampleData
    {
        // add 100

        private static List<string> _breedCache = null;
        private static int _numberOfBreeds;
        

        public static void AddBovines(this DomainDataDbContext context, int numberToAdd)
        {
            var bovines = Enumerable.Range(1, numberToAdd).Select(i => CreateRandomBovine(i, (seed) => GetRandomBreed(context,seed))); // possibly my first curry
            context.Bovines.AddRange(bovines);

        }

        static string GetRandomBreed(DomainDataDbContext context, int seed)
        {
            
            if (_breedCache == null)
            {
                _breedCache = context.Breeds.ToList().Select(b => b.Name).ToList();
                _numberOfBreeds = _breedCache.Count();
            }

            var randomBreedIndex = new Random(seed).Next(0,_numberOfBreeds);
            return _breedCache[randomBreedIndex];

        }

        static void SetUpProgeny(DomainDataDbContext context)
        {
            throw new NotImplementedException();
        }

        static DateTimeOffset? GetRandomCastrationDateOrDefault(int seed)
        {
            var castrate = new Random(seed).Next(0, 9) > 2;
            if (castrate)
            {
                return new DateTimeOffset(new DateTime(new Random(seed).Next(2005,2017), new Random(seed).Next(1,13),new Random(seed).Next(1,29)));
            }
            return default(DateTimeOffset);
        }
        
        static Bovine CreateRandomBovine(int bovineNumber, Func<int,string> randomBreedProvider)
        {
            var seed = Guid.NewGuid().GetHashCode();

            var isMale = new Random(bovineNumber).Next(0, 2) == 0;

            var ungendered = new Bovine()
            {
                NickName = $"Bovine {bovineNumber.ToString()}",
                BirthDate =
                    new DateTimeOffset(new DateTime(new Random(seed).Next(2005,2017), new Random(seed).Next(1, 13),
                        new Random(seed).Next(1, 28))),
                Bolus = Guid.NewGuid().ToString().Substring(0,8),
                Brand = Guid.NewGuid().ToString().Substring(0, 8),
                EarTag = Guid.NewGuid().ToString().Substring(0, 8),
                Breed = randomBreedProvider(seed),
                
               
            };

            if (isMale)



                return new MaleBovine()
                {
                    BirthDate = ungendered.BirthDate,
                    Bolus = ungendered.Bolus,
                    Brand = ungendered.Brand,
                    EarTag = ungendered.EarTag,
                    Breed = ungendered.Breed,
                    NickName = ungendered.NickName,
                    

                    CastrationDate = GetRandomCastrationDateOrDefault(seed)
                   
                };

            else
                return new FemaleBovine()
                {
                    BirthDate = ungendered.BirthDate,
                    Bolus = ungendered.Bolus,
                    Brand = ungendered.Brand,
                    EarTag = ungendered.EarTag,
                    Breed = ungendered.Breed,
                    NickName = ungendered.NickName



                };
        }
    }

}
