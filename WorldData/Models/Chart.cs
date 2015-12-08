using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldData.Models
{
    public class Chart
    {
        [Key]
        public int ChartId { get; set; }
        public ApplicationUser Owner { get; set; }

        public virtual IList<ChartItem> ChartItems { get; set; }

        public Chart()
        {
            ChartItems = new List<ChartItem>();
        }
    }
}