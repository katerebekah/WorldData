using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Runtime.Serialization;

namespace WorldData.Models
{
    [DataContract(IsReference = true)]
    public class City
    {
        [Key]
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public string ApiURL { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        
        public virtual Country Country { get; set; }
    }
}