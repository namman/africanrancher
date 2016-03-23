using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.Extensions.PlatformAbstractions;

namespace africanrancher.Models.Domain.SampleData
{
    /// <summary>
    ///     Provides an unlimited number of random names; names lengthen as list exhausted.
    /// </summary>
    public class RandomNameProvider
    {
        private readonly ImmutableList<string> _allNames;
        private readonly Random _random;
        private ArrayList _remainingNames;
        private int _numberOfTimesListExhausted;

        public RandomNameProvider(IEnumerable<string> listOfNames)
        {
            _allNames = listOfNames.ToImmutableList();
          
            _remainingNames = new ArrayList(_allNames);
            _random = new Random(Guid.NewGuid().GetHashCode());
        }

        public string GetRandomName()
        {
            if (_remainingNames.Count == 0)
                RefreshRemainingNames();

            var name = new StringBuilder();
            for (var i = 0; i < _numberOfTimesListExhausted + 1; i++)
            {
                var randomIndex = _random.Next(0, _remainingNames.Count);
                var randomName = _remainingNames[randomIndex];
                name.Append($"{randomName} ");
                _remainingNames.RemoveAt(randomIndex);
            }


            return name.ToString().TrimEnd();
        }

       

        private void RefreshRemainingNames()
        {
            _numberOfTimesListExhausted++;
            _remainingNames = new ArrayList(_allNames);
          
        }
    }
}