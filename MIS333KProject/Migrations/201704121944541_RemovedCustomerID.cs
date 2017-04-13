namespace MIS333KProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCustomerID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckingAccounts", "CustomerEmail", "dbo.Customers");
            DropForeignKey("dbo.SavingsAccounts", "CustomerEmail", "dbo.Customers");
            DropIndex("dbo.CheckingAccounts", new[] { "CustomerEmail" });
            DropIndex("dbo.SavingsAccounts", new[] { "CustomerEmail" });
            AddColumn("dbo.Customers", "phoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "UserId", c => c.String());
            AddColumn("dbo.Employees", "EmpType", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "phoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "UserId", c => c.String());
            AlterColumn("dbo.CheckingAccounts", "CustomerEmail", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.CheckingAccounts", "AccountName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Zipcode", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SavingsAccounts", "CustomerEmail", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SavingsAccounts", "AccountName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Zipcode", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "SSN", c => c.String(nullable: false));
            CreateIndex("dbo.CheckingAccounts", "CustomerEmail");
            CreateIndex("dbo.SavingsAccounts", "CustomerEmail");
            AddForeignKey("dbo.CheckingAccounts", "CustomerEmail", "dbo.Customers", "Email", cascadeDelete: true);
            AddForeignKey("dbo.SavingsAccounts", "CustomerEmail", "dbo.Customers", "Email", cascadeDelete: true);
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "MiddleInitial");
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "MiddleInitial");
            DropColumn("dbo.Employees", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Phone", c => c.String());
            AddColumn("dbo.Employees", "MiddleInitial", c => c.String());
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Customers", "Phone", c => c.String());
            AddColumn("dbo.Customers", "MiddleInitial", c => c.String());
            AddColumn("dbo.Customers", "Password", c => c.String());
            DropForeignKey("dbo.SavingsAccounts", "CustomerEmail", "dbo.Customers");
            DropForeignKey("dbo.CheckingAccounts", "CustomerEmail", "dbo.Customers");
            DropIndex("dbo.SavingsAccounts", new[] { "CustomerEmail" });
            DropIndex("dbo.CheckingAccounts", new[] { "CustomerEmail" });
            AlterColumn("dbo.Employees", "SSN", c => c.String());
            AlterColumn("dbo.Employees", "Zipcode", c => c.String());
            AlterColumn("dbo.Employees", "State", c => c.String());
            AlterColumn("dbo.Employees", "City", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.SavingsAccounts", "AccountName", c => c.String());
            AlterColumn("dbo.SavingsAccounts", "CustomerEmail", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "DOB", c => c.String());
            AlterColumn("dbo.Customers", "Zipcode", c => c.String());
            AlterColumn("dbo.Customers", "State", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            AlterColumn("dbo.CheckingAccounts", "AccountName", c => c.String());
            AlterColumn("dbo.CheckingAccounts", "CustomerEmail", c => c.String(maxLength: 128));
            DropColumn("dbo.Employees", "UserId");
            DropColumn("dbo.Employees", "phoneNumber");
            DropColumn("dbo.Employees", "EmpType");
            DropColumn("dbo.Customers", "UserId");
            DropColumn("dbo.Customers", "phoneNumber");
            CreateIndex("dbo.SavingsAccounts", "CustomerEmail");
            CreateIndex("dbo.CheckingAccounts", "CustomerEmail");
            AddForeignKey("dbo.SavingsAccounts", "CustomerEmail", "dbo.Customers", "Email");
            AddForeignKey("dbo.CheckingAccounts", "CustomerEmail", "dbo.Customers", "Email");
        }
    }
}
