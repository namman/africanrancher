using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace africanrancher.Models.Domain
{
    public class Pairing
    {
        public int Id { get; set; }

        public int BovineId { get; set; }
        public Bovine Bovine { get; set; }
        
        public int? SireId { get; set; }
        public MaleBovine Sire { get; set; }
        
        public int? DamId { get; set; }
        public FemaleBovine Dam { get; set; }
    }
}
