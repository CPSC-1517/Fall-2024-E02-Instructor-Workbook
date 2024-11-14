using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindLibrary.Entities
{
    //This is just an Example Class to show more Data Annotation - Not part of the Database.
    public class PersonExample
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must provide a {0}.")]
        [MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must provide a {0}.")]
        [MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "You must provide a {0}.")]
        //Validation for Phone numbers, Regex validation provided by Microsoft 
        //This is not the best, but useable
        [Phone(ErrorMessage = "Please enter a valid {0}.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must provide a {0}.")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} must be {1} or greater.")]
        public int Age { get; set; }

        [Display(Name = "SIN")]
        [Required(ErrorMessage = "You must provide a {0}.")]
        [RegularExpression("^\\d{3}-\\d{3}-\\d{3}$", 
            ErrorMessage = "{0} must be in the format ###-###-###")]
        public string SocialInsuranceNumber { get; set; }

        public string Email { get; set; }

        public string ConfirmEmail { get; set; }

        public DateOnly Birthday { get; set; }
    }
}