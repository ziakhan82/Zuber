using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zuber.Models
{
    public class Dot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //[RegularExpression(@"^\d+\.\d{0,16}$")]
        [Range(-90,90)]
        public double Lat { get; set; }
        [Required]
        //[RegularExpression(@"^\d+\.\d{0,16}$")]
        [Range(-180, 180)]
        public double Long { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [ForeignKey("ZuberUser")]
        [Required]
        public int ZuberUserID { get; set; }
        public bool Hidden { get; set; }
        
        public ZuberUser ZuberUser { get; set; }

    }
}
