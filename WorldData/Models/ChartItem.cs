using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorldData.Models
{
    public class ChartItem
    {
        [Key]
        public int ChartItemId { get; set; }
        public int ChartId { get; set; }

        public virtual City City { get; set; }
        
    }
}