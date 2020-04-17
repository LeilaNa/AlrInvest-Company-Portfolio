using AlrInvestSupply.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlrInvestSupply.Models
{
    public class AlrDbContext:DbContext
    {
        public AlrDbContext() : base("name=cString")
        {

        }

        public DbSet<About> About { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Slogans> Slogans { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}