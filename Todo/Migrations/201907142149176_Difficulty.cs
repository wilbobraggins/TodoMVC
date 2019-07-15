namespace Todo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Difficulty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoLists", "Difficulty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoLists", "Difficulty");
        }
    }
}
