namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoListTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Description = c.String(nullable: false, maxLength: 200),
                        Time = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DoLists");
        }
    }
}
