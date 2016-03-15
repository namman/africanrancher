using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace africanrancher.Models.Domain
{
    public class HeardMovement
    {
        public int Id { get; set; }
        public DateTimeOffset Entry { get; set; }

        public Cow Cow { get; set; }
        public Heard Heard { get; set; }
    }

     // to find all the cows in a heard:  
        //  get all the movements for that heard
        //  find the most recent one
        //  find the cows that are not sold or dead
}
