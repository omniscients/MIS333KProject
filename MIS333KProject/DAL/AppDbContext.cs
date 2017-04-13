using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MIS333KProject.Models;

namespace MIS333KProject.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base("KProject") { } 

        public DbSet<CheckingAccount> CheckingAccounts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<IRA> IRAs { get; set; }

        public DbSet<SavingsAccount> SavingsAccounts { get; set; }


    }
}