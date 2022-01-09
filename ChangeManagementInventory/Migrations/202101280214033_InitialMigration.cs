namespace ChangeManagementInventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        Description = c.String(),
                        Version = c.String(),
                        ManufacturerId = c.Guid(nullable: false),
                        SupplierId = c.Guid(nullable: false),
                        Support = c.Boolean(),
                        UserManualPath = c.String(),
                        OpsManualPath = c.String(),
                        DBManualPath = c.String(),
                        HighAvailable = c.Boolean(),
                        IsActive = c.Boolean(),
                        UseProcesses = c.Boolean(),
                        NeedADAuthentication = c.Boolean(),
                        AppTypeId = c.Guid(nullable: false),
                        AppLicenseTypeId = c.Guid(nullable: false),
                        AppSupportTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppLicenseTypes", t => t.AppLicenseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AppTypes", t => t.AppTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.ManufacturerId, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.SupplierId, cascadeDelete: false)
                .Index(t => t.ManufacturerId)
                .Index(t => t.SupplierId)
                .Index(t => t.AppTypeId)
                .Index(t => t.AppLicenseTypeId);
            
            CreateTable(
                "dbo.AppLicenseTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        isSupplier = c.Boolean(nullable: false),
                        isManufacturer = c.Boolean(nullable: false),
                        BusinessPhone = c.String(),
                        FaxPhone = c.String(),
                        Address = c.String(),
                        stringCity = c.String(),
                        stringStateProvince = c.String(),
                        stringZipCode = c.String(),
                        stringCountryRegion = c.String(),
                        stringWebPage = c.String(),
                        stringNotes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "SupplierId", "dbo.Companies");
            DropForeignKey("dbo.Applications", "ManufacturerId", "dbo.Companies");
            DropForeignKey("dbo.Applications", "AppTypeId", "dbo.AppTypes");
            DropForeignKey("dbo.Applications", "AppLicenseTypeId", "dbo.AppLicenseTypes");
            DropIndex("dbo.Applications", new[] { "AppLicenseTypeId" });
            DropIndex("dbo.Applications", new[] { "AppTypeId" });
            DropIndex("dbo.Applications", new[] { "SupplierId" });
            DropIndex("dbo.Applications", new[] { "ManufacturerId" });
            DropTable("dbo.Companies");
            DropTable("dbo.AppTypes");
            DropTable("dbo.AppLicenseTypes");
            DropTable("dbo.Applications");
        }
    }
}
