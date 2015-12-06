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
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }

        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
    }
}