namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agency", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Agency", "LastUpdateDate", c => c.DateTime());
            AddColumn("dbo.City", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.City", "LastUpdateDate", c => c.DateTime());
            AddColumn("dbo.Department", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Department", "LastUpdateDate", c => c.DateTime());
            AddColumn("dbo.CodeCategory", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CodeCategory", "LastUpdateDate", c => c.DateTime());
            AddColumn("dbo.Code", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Code", "LastUpdateDate", c => c.DateTime());
            AddColumn("dbo.CustomerPolicy", "EffectiveStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomerPolicy", "DueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomerPolicy", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomerPolicy", "LastUpdateDate", c => c.DateTime());
            AddColumn("dbo.Customer", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customer", "LastUpdateDate", c => c.DateTime());
            AddColumn("dbo.Policy", "DeleteDate", c => c.DateTime());
            AddColumn("dbo.Policy", "CoveragePercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Policy", "CoverageTerm", c => c.Byte(nullable: false));
            AddColumn("dbo.Policy", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Policy", "LastUpdateDate", c => c.DateTime());
            DropColumn("dbo.Agency", "CreateDtm");
            DropColumn("dbo.Agency", "LastUpdateDtm");
            DropColumn("dbo.City", "CreateDtm");
            DropColumn("dbo.City", "LastUpdateDtm");
            DropColumn("dbo.Department", "CreateDtm");
            DropColumn("dbo.Department", "LastUpdateDtm");
            DropColumn("dbo.CodeCategory", "CreateDtm");
            DropColumn("dbo.CodeCategory", "LastUpdateDtm");
            DropColumn("dbo.Code", "CreateDtm");
            DropColumn("dbo.Code", "LastUpdateDtm");
            DropColumn("dbo.CustomerPolicy", "EfectiveStartDtm");
            DropColumn("dbo.CustomerPolicy", "CreateDtm");
            DropColumn("dbo.CustomerPolicy", "LastUpdateDtm");
            DropColumn("dbo.Customer", "CreateDtm");
            DropColumn("dbo.Customer", "LastUpdateDtm");
            DropColumn("dbo.Policy", "CoveragePercentaje");
            DropColumn("dbo.Policy", "Validity");
            DropColumn("dbo.Policy", "CreateDtm");
            DropColumn("dbo.Policy", "LastUpdateDtm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Policy", "LastUpdateDtm", c => c.DateTime());
            AddColumn("dbo.Policy", "CreateDtm", c => c.DateTime(nullable: false));
            AddColumn("dbo.Policy", "Validity", c => c.Byte(nullable: false));
            AddColumn("dbo.Policy", "CoveragePercentaje", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Customer", "LastUpdateDtm", c => c.DateTime());
            AddColumn("dbo.Customer", "CreateDtm", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomerPolicy", "LastUpdateDtm", c => c.DateTime());
            AddColumn("dbo.CustomerPolicy", "CreateDtm", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomerPolicy", "EfectiveStartDtm", c => c.DateTime(nullable: false));
            AddColumn("dbo.Code", "LastUpdateDtm", c => c.DateTime());
            AddColumn("dbo.Code", "CreateDtm", c => c.DateTime(nullable: false));
            AddColumn("dbo.CodeCategory", "LastUpdateDtm", c => c.DateTime());
            AddColumn("dbo.CodeCategory", "CreateDtm", c => c.DateTime(nullable: false));
            AddColumn("dbo.Department", "LastUpdateDtm", c => c.DateTime());
            AddColumn("dbo.Department", "CreateDtm", c => c.DateTime(nullable: false));
            AddColumn("dbo.City", "LastUpdateDtm", c => c.DateTime());
            AddColumn("dbo.City", "CreateDtm", c => c.DateTime(nullable: false));
            AddColumn("dbo.Agency", "LastUpdateDtm", c => c.DateTime());
            AddColumn("dbo.Agency", "CreateDtm", c => c.DateTime(nullable: false));
            DropColumn("dbo.Policy", "LastUpdateDate");
            DropColumn("dbo.Policy", "CreateDate");
            DropColumn("dbo.Policy", "CoverageTerm");
            DropColumn("dbo.Policy", "CoveragePercentage");
            DropColumn("dbo.Policy", "DeleteDate");
            DropColumn("dbo.Customer", "LastUpdateDate");
            DropColumn("dbo.Customer", "CreateDate");
            DropColumn("dbo.CustomerPolicy", "LastUpdateDate");
            DropColumn("dbo.CustomerPolicy", "CreateDate");
            DropColumn("dbo.CustomerPolicy", "DueDate");
            DropColumn("dbo.CustomerPolicy", "EffectiveStartDate");
            DropColumn("dbo.Code", "LastUpdateDate");
            DropColumn("dbo.Code", "CreateDate");
            DropColumn("dbo.CodeCategory", "LastUpdateDate");
            DropColumn("dbo.CodeCategory", "CreateDate");
            DropColumn("dbo.Department", "LastUpdateDate");
            DropColumn("dbo.Department", "CreateDate");
            DropColumn("dbo.City", "LastUpdateDate");
            DropColumn("dbo.City", "CreateDate");
            DropColumn("dbo.Agency", "LastUpdateDate");
            DropColumn("dbo.Agency", "CreateDate");
        }
    }
}
