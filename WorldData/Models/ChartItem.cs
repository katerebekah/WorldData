using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WorldData.Models
{
    public class ChartItem
    {
        [Key]
        [DataMember]
        public int ChartItemId { get; set; }
        [DataMember]
        public int ChartId { get; set; }

        [DataMember]
        public virtual City City { get; set; }
        
    }
}