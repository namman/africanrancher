using System;
using System.Collections.Generic;


namespace africanrancher.Models.Domain
{
    public class Ailment
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTimeOffset? Diagnosed { get; set; }

       public  Bovine Bovine { get; set; }

        public List<Treatment> Treatments { get; set; }
    }
}