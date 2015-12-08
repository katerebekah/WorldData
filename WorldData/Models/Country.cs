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
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual IList<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }
    }
}