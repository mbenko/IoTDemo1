namespace iotDemoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baseDataModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.iotDevices", new[] { "CreatedAt" });
            DropPrimaryKey("dbo.iotDevices");
            AlterColumn("dbo.iotDevices", "Id", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("dbo.iotDevices", "CreatedAt", c => c.DateTimeOffset(precision: 7));
            AddPrimaryKey("dbo.iotDevices", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.iotDevices");
            AlterColumn("dbo.iotDevices", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.iotDevices", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.iotDevices", "Id");
            CreateIndex("dbo.iotDevices", "CreatedAt", clustered: true);
        }
    }
}
