using System;

namespace africanrancher.Models.Domain
{
    public class MaleCow : Cow
    {
       
        public bool? Castrated { get; set; }
        public DateTimeOffset? CastrationDate { get; set; }
    }
}