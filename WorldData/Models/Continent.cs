using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WorldData.Models
{
    public class Continent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Country> Countries { get; set; }

        public Continent()
        {
            Countries = new List<Country>();
        }
    }
}