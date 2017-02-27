namespace iotDemoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.iotDevices",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Key = c.String(),
                        Type = c.String(),
                        Owner = c.String(),
                        RegisterDt = c.DateTime(nullable: false),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(precision: 7),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id, clustered: false)
                .Index(t => t.CreatedAt, clustered: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.iotDevices", new[] { "CreatedAt" });
            DropTable("dbo.iotDevices");
        }
    }
}
