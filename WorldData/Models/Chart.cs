using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldData.Models
{
    public class Chart
    {
        [Key]
        public int ChartId { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public string ApiUrl { get; set; }
        public string ProfileId { get; set; }

        public virtual City City { get; set; }
        public virtual List<ApplicationUser> Owners {get; set;}

        public Chart()
        {
            Owners = new List<ApplicationUser>();
        }
    }
}