using Microsoft.EntityFrameworkCore;

namespace africanrancher.Models.Domain
{
   

    public class DomainDataDbContext : DbContext
    {
        public DomainDataDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=africanrancher;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<BreedType> Breeds { get; set; }
        
        // We use the Table Per Hierarchy (TPH) strategy to map Female Cows and Male Cows to a single table, for performance and simplicity, at the expense of some non-normalization.
        public DbSet<Bovine> Bovines { get; set; } 
        
        public DbSet<MaleBovine> MaleBovines { get; set; } 
        public DbSet<FemaleBovine> FemaleBovines { get; set; }  
        
        public DbSet<Heard> Heards { get; set; } 

        public DbSet<HeardMovement> HeardMovements { get; set; } 
        public DbSet<Weighing> Weighings { get; set; }
        public DbSet<Ailment> Ailments { get; set; } 
        public DbSet<Treatment> Treatments { get; set; }
        
        public DbSet<Pairing> Pairings { get; set; }

        
       
    }

   
    
    

    
}
