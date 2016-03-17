using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using africanrancher.Models.Domain;

namespace africanrancher.Controllers
{
    public static class DtoTransformations
    {
        public static BovineDto ToDto(this Bovine bovine)
        {
            return new BovineDto(bovine);
        }
    }

    public class BovineDto
    {
        private readonly Bovine _bovine;

        public BovineDto(Bovine bovine)
        {
            _bovine = bovine;
        }

        public string EarTag => _bovine.EarTag;
    }
}
