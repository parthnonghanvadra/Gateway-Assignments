using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SourceControlAssignment1.Models
{
    [Bind(Exclude = "UserID")]
    public class UserRegistration
    {
        [Key]
        [ScaffoldColumn(false)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [CustomAttribute.MinAge(18)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirm Email is Required")]
        [DataType(DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Email Not Matched")]
        public string ConfirmEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        //[Display(Name = "Enter Your Phone Number")]
        [RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{4})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }

        //[Display(Name = "Enter Your BirthDate: ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime? BirthDate { get; set; }

        [Url]
        [Display(Name = "User's LinkedIn URL")]
        public string URL { get; set; }

    }
}