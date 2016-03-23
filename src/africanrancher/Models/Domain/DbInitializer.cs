﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using africanrancher.Models.Domain.SampleData;
using Microsoft.Data.Entity;

namespace africanrancher.Models.Domain
{
    public class DbInitializer
    {
        private readonly DomainDataDbContext _context;
        private RandomNameProvider _randomNameProvider;

        public DbInitializer(DomainDataDbContext context)
        {
            _context = context;
            
        }

        public void InjectRandomNameProvider(RandomNameProvider randomNameProvider)
        {
            _randomNameProvider = randomNameProvider;
        }

        public async Task AddSampleCattle()
        {
            if (_randomNameProvider == null)
            {
                throw new MissingFieldException("Must inject random name provider first.");
            }
            _context.AddBovines(100,_randomNameProvider);
            await _context.SaveChangesAsync();
        }
        
        public async Task InitializeBreeds()
        {

            _context.Breeds.AddRange(new []
            {
                new BreedType() {Name = "Friesian"},
                new BreedType() {Name = "Sahiwal"}, 
                new BreedType() {Name = "East African Zebu"},
                new BreedType() {Name = "Simmental"},
                new BreedType() {Name = "Charolis"},
                new BreedType() {Name = "Hereford"},
                new BreedType() {Name = "Boran"},
            });

            await _context.SaveChangesAsync();
        }

        
    }
}
