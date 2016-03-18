using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace africanrancher.Models.Domain
{
    public class BreedType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get;set; }
        public string Name { get; set; }
    }


    

    
}