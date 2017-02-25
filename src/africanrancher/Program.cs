using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using africanrancher.Models.Domain;

namespace africanrancher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DomainDataDbContext domainDataDbContext = new DomainDataDbContext();
            domainDataDbContext.Database.EnsureCreated();
        }
    }
}
