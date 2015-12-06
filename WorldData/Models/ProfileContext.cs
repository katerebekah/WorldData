using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WorldData.Models
{
    public class ProfileContext : ApplicationDbContext
    {
        public virtual IDbSet<Chart> Charts { get; set; }
        public virtual IDbSet<Profile> Profiles { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<State> States { get; set; }
        public virtual IDbSet<Country> Countries { get; set; }
        public virtual IDbSet<Continent> Continents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}