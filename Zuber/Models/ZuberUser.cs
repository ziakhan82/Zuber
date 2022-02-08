using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zuber.Models
{
    public class ZuberUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]+\s?[A-Za-z]*$", ErrorMessage = "Please, insert your name using only letters")]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please, enter valid email adress")]
        public string Email { get; set; }
        [Phone]
        [Required]
        [RegularExpression(@"^\+?[0-9]{6,11}$", ErrorMessage = "Please, enter valid phone number")]
        public string PhoneNo { get; set; }
        //password needs to be hashed
        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        public bool Driver { get; set; }

        [ForeignKey("Ride")]
        public int? RideId { get; set; }
        public Ride? Ride { get; set; }

        [ForeignKey("Dot")]
        public int? DotId { get; set; }

    }
}
