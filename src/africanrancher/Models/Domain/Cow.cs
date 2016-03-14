using System;

namespace africanrancher.Models.Domain
{
    public class Cow
    {
        public int Id { get; set; }
        
        public string EarTag { get; set; }
        public string Bolus { get; set; }
        
        public string Brand { get; set; }

        
        public MaleCow Sire { get; set; }

        
        public FemaleCow Dam { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public int Breed { get; set; }
    }
}

