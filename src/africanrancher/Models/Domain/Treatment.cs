using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace africanrancher.Models.Domain
{
    public class Treatment
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTimeOffset Applied { get; set; }
        public Ailment Ailment { get; set; }


    }
}