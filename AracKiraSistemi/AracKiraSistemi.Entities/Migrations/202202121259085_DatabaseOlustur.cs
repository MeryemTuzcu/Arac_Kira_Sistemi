namespace AracKiraSistemi.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAraba",
                c => new
                    {
                        ArabaId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128, unicode: false),
                        Model = c.String(maxLength: 128, unicode: false),
                        Branch = c.String(maxLength: 128, unicode: false),
                        Year = c.Int(nullable: false),
                        Km = c.Int(nullable: false),
                        LeaseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArabaId)
                .ForeignKey("dbo.tblKiraTuru", t => t.LeaseTypeId, cascadeDelete: true)
                .Index(t => t.LeaseTypeId);
            
            CreateTable(
                "dbo.tblKiraTuru",
                c => new
                    {
                        KiraTuruId = c.Int(nullable: false, identity: true),
                        DailyPrice = c.Int(nullable: false),
                        WeeklyPrice = c.Int(nullable: false),
                        MonthlyPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KiraTuruId);
            
            CreateTable(
                "dbo.tblSepet",
                c => new
                    {
                        SepetId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false, storeType: "date"),
                        DeliveryDate = c.DateTime(nullable: false, storeType: "date"),
                        TotalPrice = c.Decimal(nullable: false, precision: 15, scale: 2),
                    })
                .PrimaryKey(t => t.SepetId)
                .ForeignKey("dbo.tblAraba", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.tblMusteri", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.tblMusteri",
                c => new
                    {
                        MusteriId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 128, unicode: false),
                        LastName = c.String(maxLength: 128, unicode: false),
                        BornDate = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.String(maxLength: 16, unicode: false),
                    })
                .PrimaryKey(t => t.MusteriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblSepet", "CustomerId", "dbo.tblMusteri");
            DropForeignKey("dbo.tblSepet", "CarId", "dbo.tblAraba");
            DropForeignKey("dbo.tblAraba", "LeaseTypeId", "dbo.tblKiraTuru");
            DropIndex("dbo.tblSepet", new[] { "CarId" });
            DropIndex("dbo.tblSepet", new[] { "CustomerId" });
            DropIndex("dbo.tblAraba", new[] { "LeaseTypeId" });
            DropTable("dbo.tblMusteri");
            DropTable("dbo.tblSepet");
            DropTable("dbo.tblKiraTuru");
            DropTable("dbo.tblAraba");
        }
    }
}
