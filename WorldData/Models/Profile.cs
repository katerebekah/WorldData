using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldData.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public ApplicationUser Owner { get; set; }

        public virtual City City { get; set; }
        public virtual IList<Chart> Charts { get; set; }

        public Profile()
        {
            Charts = new List<Chart>();
        }
    }
}