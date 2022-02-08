using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zuber.Models
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Ride")]
        public int RideID { get; set; }
        [ForeignKey("ZuberUser")]
        public int? ZuberUserID { get; set; }

        [Required]
        public Ride Ride { get; set; }
        //[Required]
        //OnDeleteCascade removed from this property because SQL complains
        //also made property nullable to make on delete no action
        // Therefore after deleting user we must manually delete all passenger instances of the user
        public ZuberUser? ZuberUser{get;set;}

    }
}
