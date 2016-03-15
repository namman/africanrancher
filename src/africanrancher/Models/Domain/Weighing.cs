using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace africanrancher.Models.Domain
{
    public class Weighing
    {
        public int Id { get; set; }
        
        public Cow Cow { get; set; }

        public float WeightInKgs { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}