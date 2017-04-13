using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS333KProject.Models
{
    public class IRA
    {
        [Key, ForeignKey("Customer")]
        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public string CustomerEmail { get; set; } //this displays the customer's email

        public string AccountName { get; set; } //this has a default value, but can be changed by the customer

        public AccountType AccountType { get; set; }

        public virtual Customer Customer { get; set; }
    }
}