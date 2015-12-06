using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldData.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }
        public virtual IList<State> States { get; set; }
        public virtual IList<City> Cities { get; set; }

        public Country()
        {
            States = new List<State>();
            Cities = new List<City>();
        }
    }
}