using ContactRecord.Core.SeedWork;
using ContactRecord.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactRecord.Infrastructure
{
    public class ContactRecordContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "cr";

        public DbSet<ContactRecord.Core.Entities.ContactRecord> ContactRecord { get; set; }
        
        public ContactRecordContext(DbContextOptions<ContactRecordContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactRecordEntityTypeConfiguration());
            
            //modelBuilder.Seed();
        }
    }
}
