using System;
using System.Collections.Generic;


namespace africanrancher.Models.Domain
{
    public class Ailment
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTimeOffset? Diagnosed { get; set; }

       public  Cow Cow { get; set; }

        public List<Treatment> Treatments { get; set; }
    }
}