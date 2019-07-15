namespace Todo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoLists", "Name", c => c.String(maxLength: 60));
            AlterColumn("dbo.TodoLists", "Type", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.TodoLists", "Difficulty", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoLists", "Difficulty", c => c.String());
            AlterColumn("dbo.TodoLists", "Type", c => c.String());
            AlterColumn("dbo.TodoLists", "Name", c => c.String());
        }
    }
}
