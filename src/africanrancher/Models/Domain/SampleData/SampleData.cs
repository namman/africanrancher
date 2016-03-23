using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Microsoft.Data.Entity;

namespace africanrancher.Models.Domain.SampleData
{
    public static class SampleData
    {
        private static List<string> _breedCache;
        private static int _numberOfBreeds;
        private static readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
        private static readonly double PercentageOfMalesThatBreed = 0.8;
        private static readonly double PercentageOfFemalesThatBreed = 0.9;
        private static readonly double PercentageOfMalesToCastrate = 0.1;
        private static readonly double PercentageWithUnknownAncestry = 0.1;
        

        public static void AddBovines(this DomainDataDbContext context, int numberToAdd, RandomNameProvider randomNameProvider)
        {
            var bovines =
                Enumerable.Range(1, numberToAdd)
                    .Select(i => CreateRandomBovine(i, seed => GetRandomBreed(context, _random), _random, randomNameProvider))
                    // possibly my first curry
                    .ToList();
            SetUpProgeny(bovines, _random);
            context.Bovines.AddRange(bovines,GraphBehavior.IncludeDependents);
        }

        private static string GetRandomBreed(DomainDataDbContext context, Random random)
        {
            if (_breedCache == null)
            {
                _breedCache = context.Breeds.ToList().Select(b => b.Name).ToList();
                _numberOfBreeds = _breedCache.Count();
            }

            var randomBreedIndex = random.Next(0, _numberOfBreeds);
            return _breedCache[randomBreedIndex];
        }

        private static void SetUpProgeny(IEnumerable<Bovine> bovines, Random random)
        {
            // order bovines by birth date
            // get oldest males and females, up to maximum each of total number of cattle.
            // remember to exclude castrated males
            // remove those from list, add to breeders list
            // for 80% of the remaining, randomly select a sire and dam
            var bovinesList = bovines.ToList();
            var totalBovines = bovinesList.Count();

            var maxNumberOfMalesToMakeBreedrs = Convert.ToInt16(totalBovines*PercentageOfMalesThatBreed);
            var maxNumberOfFemalesToMakeBreeders = Convert.ToInt16(totalBovines*PercentageOfFemalesThatBreed);


            var bovinesOrderedOldestToYoungest = bovinesList.OrderByDescending(b => b.BirthDate);

            var breederMales = bovinesOrderedOldestToYoungest
                .Where(b => b is MaleBovine)
                .Where(b => (b as MaleBovine).CastrationDate.HasValue == false)
                .Take(maxNumberOfMalesToMakeBreedrs)
                .ToList();


            var breederMalesCount = breederMales.Count();

            var breederFemales = bovinesOrderedOldestToYoungest
                .Where(b => b is FemaleBovine)
                .Take(maxNumberOfFemalesToMakeBreeders)
                .ToList();

            var breederFemalesCount = breederFemales.Count();

            var remainingNonBreeders = bovinesList.Where(b => !breederMales.Union(breederFemales).Contains(b)).ToList();

            Contract.Assert(remainingNonBreeders.Count() + breederMales.Union(breederFemales).Count() ==
                            bovinesList.Count());

            foreach (var nonBreeder in remainingNonBreeders)
            {
                var hasKnownSire = random.NextDouble() < PercentageWithUnknownAncestry;
                var hasKnownDam = random.NextDouble() < PercentageWithUnknownAncestry;

                var randomSire = hasKnownSire
                    ? breederMales[random.Next(0, (breederMalesCount - 1) >= 0 ? breederMalesCount -1 : 0)]
                    : null;

                var randomDam = hasKnownDam
                    ? breederFemales[random.Next(0, (breederFemalesCount - 1) >= 0 ? breederFemalesCount - 1 : 0)] : null;

                nonBreeder.Sire = (MaleBovine) randomSire;
                nonBreeder.Dam = (FemaleBovine) randomDam;
            }
        }

        private static DateTimeOffset? GetRandomCastrationDateOrNull(Random random)
        {
            var castrate = random.NextDouble() < PercentageOfMalesToCastrate;
            if (castrate)
            {
                return new DateTimeOffset(new DateTime(random.Next(2005, 2017), random.Next(1, 13), random.Next(1, 29)));
            }
            return null;
        }

        private static Bovine CreateRandomBovine(int bovineNumber, Func<Random, string> randomBreedProvider,
            Random random, RandomNameProvider randomNameProvider)
        {
            var isMale = random.Next(0, 2) == 0;

            var ungendered = new Bovine
                             {
                                 NickName = randomNameProvider.GetRandomName(),
                                 BirthDate =
                                     new DateTimeOffset(new DateTime(random.Next(2005, 2017), random.Next(1, 13),
                                     random.Next(1, 28))),
                                 Bolus = Guid.NewGuid().ToString().Substring(0, 8),
                                 Brand = Guid.NewGuid().ToString().Substring(0, 8),
                                 EarTag = Guid.NewGuid().ToString().Substring(0, 8),
                                 Breed = randomBreedProvider(random)
                             };

            if (isMale)


                return new MaleBovine
                       {
                            NickName = ungendered.NickName,
                            BirthDate = ungendered.BirthDate,
                           Bolus = ungendered.Bolus,
                           Brand = ungendered.Brand,
                           EarTag = ungendered.EarTag,
                           Breed = ungendered.Breed,
                          
                           CastrationDate = GetRandomCastrationDateOrNull(random)
                       };

            return new FemaleBovine
                   {
                       NickName = ungendered.NickName,
                       BirthDate = ungendered.BirthDate,
                       Bolus = ungendered.Bolus,
                       Brand = ungendered.Brand,
                       EarTag = ungendered.EarTag,
                       Breed = ungendered.Breed
                   };
        }
    }
}