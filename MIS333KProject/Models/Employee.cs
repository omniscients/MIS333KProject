using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MIS333KProject.Models
{
    public enum EmpTypes { Employee, Manager }
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address.")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name Initial")]
        public char MI { get; set; }

        [Required(ErrorMessage = "Social Security Number is required.")]
        [Display(Name = "SSN")]
        public string SSN { get; set; }

        [Required(ErrorMessage = "EmpType is required.")]
        [EnumDataType(typeof(EmpTypes))]
        [Display(Name = "EmpType")]
        public EmpTypes EmpType { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode is required.")]
        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name = "Phone Number")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        public string phoneNumber { get; set; }

        public string UserId { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }

    public enum EmployeeType { Employee, Manager};
}