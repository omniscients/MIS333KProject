namespace MIS333KProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckingAccounts",
                c => new
                    {
                        AccountNumber = c.String(nullable: false, maxLength: 128),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerEmail = c.String(maxLength: 128),
                        AccountName = c.String(),
                    })
                .PrimaryKey(t => t.AccountNumber)
                .ForeignKey("dbo.Customers", t => t.CustomerEmail)
                .Index(t => t.CustomerEmail);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleInitial = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        Phone = c.String(),
                        DOB = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.IRAs",
                c => new
                    {
                        AccountNumber = c.String(nullable: false, maxLength: 128),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerEmail = c.String(),
                        AccountName = c.String(),
                        AccountType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber)
                .ForeignKey("dbo.Customers", t => t.AccountNumber)
                .Index(t => t.AccountNumber);
            
            CreateTable(
                "dbo.SavingsAccounts",
                c => new
                    {
                        AccountNumber = c.String(nullable: false, maxLength: 128),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerEmail = c.String(maxLength: 128),
                        AccountName = c.String(),
                        AccountType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber)
                .ForeignKey("dbo.Customers", t => t.CustomerEmail)
                .Index(t => t.CustomerEmail);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleInitial = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        Phone = c.String(),
                        SSN = c.String(),
                        EmployeeType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavingsAccounts", "CustomerEmail", "dbo.Customers");
            DropForeignKey("dbo.IRAs", "AccountNumber", "dbo.Customers");
            DropForeignKey("dbo.CheckingAccounts", "CustomerEmail", "dbo.Customers");
            DropIndex("dbo.SavingsAccounts", new[] { "CustomerEmail" });
            DropIndex("dbo.IRAs", new[] { "AccountNumber" });
            DropIndex("dbo.CheckingAccounts", new[] { "CustomerEmail" });
            DropTable("dbo.Employees");
            DropTable("dbo.SavingsAccounts");
            DropTable("dbo.IRAs");
            DropTable("dbo.Customers");
            DropTable("dbo.CheckingAccounts");
        }
    }
}
