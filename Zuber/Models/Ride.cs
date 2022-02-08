using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zuber.Models
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }
        public string CarDescription { get; set; }
        [Required]
        public int PlacesRemaining{ get; set; }
        //[Required]
        //[DataType(DataType.Time)]
        //public DateTime TimeToFromZealand{get;set;}
        //public bool ToZealand { get; set; }

        [ForeignKey("ZuberUser")]
        [Required]
        public int DriverId { get; set; }
        //public ZuberUser Driver { get; set; }
    }
}
