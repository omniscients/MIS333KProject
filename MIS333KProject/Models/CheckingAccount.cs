using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MIS333KProject.Models
{
    public class CheckingAccount
    {
        [Key]//, ForeignKey("Customer")]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name = "Account Balance")]
        public Decimal Balance { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address.")]
        [Display(Name = "Customer Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string CustomerEmail { get; set; } //this displays the customer's email

        [Required(ErrorMessage = "Account Name is required.")]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; } //this has a default value, but can be changed by the customer

        public virtual Customer Customer { get; set; }
    }

    public enum AccountType { Checking, Savings, IRA, Stock }
}