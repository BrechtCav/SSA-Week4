namespace Webshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Devices", "Framework_ID", "dbo.ProgrammingFrameworks");
            DropForeignKey("dbo.Devices", "OS_ID", "dbo.OperatingSystems");
            DropIndex("dbo.Devices", new[] { "Framework_ID" });
            DropIndex("dbo.Devices", new[] { "OS_ID" });
            CreateTable(
                "dbo.ProgrammingFrameworkDevices",
                c => new
                    {
                        ProgrammingFramework_ID = c.Int(nullable: false),
                        Device_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProgrammingFramework_ID, t.Device_ID })
                .ForeignKey("dbo.ProgrammingFrameworks", t => t.ProgrammingFramework_ID, cascadeDelete: true)
                .ForeignKey("dbo.Devices", t => t.Device_ID, cascadeDelete: true)
                .Index(t => t.ProgrammingFramework_ID)
                .Index(t => t.Device_ID);
            
            CreateTable(
                "dbo.OperatingSystemDevices",
                c => new
                    {
                        OperatingSystem_ID = c.Int(nullable: false),
                        Device_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OperatingSystem_ID, t.Device_ID })
                .ForeignKey("dbo.OperatingSystems", t => t.OperatingSystem_ID, cascadeDelete: true)
                .ForeignKey("dbo.Devices", t => t.Device_ID, cascadeDelete: true)
                .Index(t => t.OperatingSystem_ID)
                .Index(t => t.Device_ID);
            
            AlterColumn("dbo.Devices", "Picture", c => c.String());
            DropColumn("dbo.Devices", "Framework_ID");
            DropColumn("dbo.Devices", "OS_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "OS_ID", c => c.Int());
            AddColumn("dbo.Devices", "Framework_ID", c => c.Int());
            DropForeignKey("dbo.OperatingSystemDevices", "Device_ID", "dbo.Devices");
            DropForeignKey("dbo.OperatingSystemDevices", "OperatingSystem_ID", "dbo.OperatingSystems");
            DropForeignKey("dbo.ProgrammingFrameworkDevices", "Device_ID", "dbo.Devices");
            DropForeignKey("dbo.ProgrammingFrameworkDevices", "ProgrammingFramework_ID", "dbo.ProgrammingFrameworks");
            DropIndex("dbo.OperatingSystemDevices", new[] { "Device_ID" });
            DropIndex("dbo.OperatingSystemDevices", new[] { "OperatingSystem_ID" });
            DropIndex("dbo.ProgrammingFrameworkDevices", new[] { "Device_ID" });
            DropIndex("dbo.ProgrammingFrameworkDevices", new[] { "ProgrammingFramework_ID" });
            AlterColumn("dbo.Devices", "Picture", c => c.Binary());
            DropTable("dbo.OperatingSystemDevices");
            DropTable("dbo.ProgrammingFrameworkDevices");
            CreateIndex("dbo.Devices", "OS_ID");
            CreateIndex("dbo.Devices", "Framework_ID");
            AddForeignKey("dbo.Devices", "OS_ID", "dbo.OperatingSystems", "ID");
            AddForeignKey("dbo.Devices", "Framework_ID", "dbo.ProgrammingFrameworks", "ID");
        }
    }
}
