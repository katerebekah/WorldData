using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WorldData.Models
{
    public class ChartContext : ApplicationDbContext
    {
        public virtual IDbSet<Chart> Charts { get; set; }
        public virtual IDbSet<ChartItem> ChartItems { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}