using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WorldData.Models
{
    [DataContract(IsReference = true)]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [DataMember]
        public string Name { get; set; }

        public virtual IList<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }
    }
}