using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MIS333KProject.Models
{
    public enum PayType { Utilities, Rent, CreditCard, Mortgage, Other }
    public class Payee
    {
        [Display(Name = "Payee Name")]
        public string PayeeName { get; set; }

        [Required(ErrorMessage = "Payee type is required.")]
        [EnumDataType(typeof(PayType))]
        [Display(Name = "Payee Type")]
        public PayType PayeeType { get; set; }

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
        [DisplayFormat(DataFormatString = "{0:##########}", ApplyFormatInEditMode = true)]
        public string phoneNumber { get; set; }
    }
}