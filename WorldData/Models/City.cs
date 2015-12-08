using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WorldData.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string ApiURL { get; set; }
        public string DisplayName { get; set; }
        
        public virtual Country Country { get; set; }
    }
}