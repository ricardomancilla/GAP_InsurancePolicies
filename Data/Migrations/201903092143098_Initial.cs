namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agency",
                c => new
                    {
                        AgencyID = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 15),
                        CityID = c.Int(nullable: false),
                        CreateDtm = c.DateTime(nullable: false),
                        LastUpdateDtm = c.DateTime(),
                    })
                .PrimaryKey(t => t.AgencyID)
                .ForeignKey("dbo.City", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DepartmentID = c.Byte(nullable: false),
                        CreateDtm = c.DateTime(nullable: false),
                        LastUpdateDtm = c.DateTime(),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Byte(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneCode = c.Byte(nullable: false),
                        CreateDtm = c.DateTime(nullable: false),
                        LastUpdateDtm = c.DateTime(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.CodeCategory",
                c => new
                    {
                        CodeCategoryID = c.Short(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 300),
                        CreateDtm = c.DateTime(nullable: false),
                        LastUpdateDtm = c.DateTime(),
                    })
                .PrimaryKey(t => t.CodeCategoryID);
            
            CreateTable(
                "dbo.Code",
                c => new
                    {
                        CodeID = c.Short(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 300),
                        CodeCategoryID = c.Short(nullable: false),
                        CreateDtm = c.DateTime(nullable: false),
                        LastUpdateDtm = c.DateTime(),
                    })
                .PrimaryKey(t => t.CodeID)
                .ForeignKey("dbo.CodeCategory", t => t.CodeCategoryID)
                .Index(t => t.CodeCategoryID);
            
            CreateTable(
                "dbo.CustomerPolicy",
                c => new
                    {
                        CustomerPolicyID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Guid(nullable: false),
                        PolicyID = c.Guid(nullable: false),
                        EfectiveStartDtm = c.DateTime(nullable: false),
                        StatusID = c.Short(nullable: false),
                        CreateDtm = c.DateTime(nullable: false),
                        LastUpdateDtm = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerPolicyID)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .ForeignKey("dbo.Policy", t => t.PolicyID)
                .ForeignKey("dbo.Code", t => t.StatusID)
                .Index(t => t.CustomerID)
                .Index(t => t.PolicyID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Guid(nullable: false),
                        Identification = c.String(maxLength: 15),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        HomePhoneNumber = c.String(maxLength: 15),
                        MobilePhoneNumber = c.String(nullable: false, maxLength: 50),
                        HomeAddress = c.String(nullable: false, maxLength: 100),
                        EmailAddress = c.String(nullable: false, maxLength: 80),
                        CityID = c.Int(nullable: false),
                        CreateDtm = c.DateTime(nullable: false),
                        LastUpdateDtm = c.DateTime(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.City", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Policy",
                c => new
                    {
                        PolicyID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 300),
                        CoveragePercentaje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Validity = c.Byte(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoverageTypeID = c.Short(nullable: false),
                        RiskTypeID = c.Short(nullable: false),
                        PolicyStatusID = c.Short(nullable: false),
                        CreateDtm = c.DateTime(nullable: false),
                        LastUpdateDtm = c.DateTime(),
                    })
                .PrimaryKey(t => t.PolicyID)
                .ForeignKey("dbo.Code", t => t.CoverageTypeID)
                .ForeignKey("dbo.Code", t => t.PolicyStatusID)
                .ForeignKey("dbo.Code", t => t.RiskTypeID)
                .Index(t => t.CoverageTypeID)
                .Index(t => t.RiskTypeID)
                .Index(t => t.PolicyStatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerPolicy", "StatusID", "dbo.Code");
            DropForeignKey("dbo.CustomerPolicy", "PolicyID", "dbo.Policy");
            DropForeignKey("dbo.Policy", "RiskTypeID", "dbo.Code");
            DropForeignKey("dbo.Policy", "PolicyStatusID", "dbo.Code");
            DropForeignKey("dbo.Policy", "CoverageTypeID", "dbo.Code");
            DropForeignKey("dbo.CustomerPolicy", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Customer", "CityID", "dbo.City");
            DropForeignKey("dbo.Code", "CodeCategoryID", "dbo.CodeCategory");
            DropForeignKey("dbo.Agency", "CityID", "dbo.City");
            DropForeignKey("dbo.City", "DepartmentID", "dbo.Department");
            DropIndex("dbo.Policy", new[] { "PolicyStatusID" });
            DropIndex("dbo.Policy", new[] { "RiskTypeID" });
            DropIndex("dbo.Policy", new[] { "CoverageTypeID" });
            DropIndex("dbo.Customer", new[] { "CityID" });
            DropIndex("dbo.CustomerPolicy", new[] { "StatusID" });
            DropIndex("dbo.CustomerPolicy", new[] { "PolicyID" });
            DropIndex("dbo.CustomerPolicy", new[] { "CustomerID" });
            DropIndex("dbo.Code", new[] { "CodeCategoryID" });
            DropIndex("dbo.City", new[] { "DepartmentID" });
            DropIndex("dbo.Agency", new[] { "CityID" });
            DropTable("dbo.Policy");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerPolicy");
            DropTable("dbo.Code");
            DropTable("dbo.CodeCategory");
            DropTable("dbo.Department");
            DropTable("dbo.City");
            DropTable("dbo.Agency");
        }
    }
}
