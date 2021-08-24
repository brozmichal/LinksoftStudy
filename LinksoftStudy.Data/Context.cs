using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinksoftStudy.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace LinksoftStudy.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<PersonEntity> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SetPersonToPersonContacts(modelBuilder);
        }

        private void SetPersonToPersonContacts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactContacteeEntity>()
                .HasOne(e => e.Contact)
                .WithMany(b => b.Contactee)
                .HasForeignKey(e => e.ContactId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ContactContacteeEntity>()
                .HasOne(e => e.Contactee)
                .WithMany(b => b.Contact)
                .HasForeignKey(e => e.ContacteeId);
        }
    }
}
