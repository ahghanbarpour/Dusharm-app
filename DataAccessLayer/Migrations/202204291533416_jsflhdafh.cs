namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jsflhdafh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.doctors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        field = c.String(),
                        family = c.String(),
                        rdate = c.String(),
                        rtime = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.patients",
                c => new
                    {
                        id = c.Int(nullable: false),
                        name = c.String(),
                        code = c.Int(nullable: false),
                        Birthday = c.String(),
                        tel = c.String(),
                        family = c.String(),
                        rdate = c.String(),
                        rtime = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.doctors", t => t.id)
                .Index(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.patients", "id", "dbo.doctors");
            DropIndex("dbo.patients", new[] { "id" });
            DropTable("dbo.patients");
            DropTable("dbo.doctors");
        }
    }
}
