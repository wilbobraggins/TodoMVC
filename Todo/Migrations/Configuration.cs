namespace Todo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Todo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Todo.Models.TodoDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Todo.Models.TodoDBContext context)
        {
            context.Todos.AddOrUpdate(i => i.Name,
                new TodoList
                {
                    Name = "Clean Fridge",
                    DueDate = DateTime.Parse("2019-8-2"),
                    Type = "Chore",
                    Hours = 1.5M,
                    Difficulty = "Medium"
                },

                new TodoList
                {
                    Name = "Go out to dinner",
                    DueDate = DateTime.Parse("2019-8-1"),
                    Type = "Fun",
                    Hours = 3.5M,
                    Difficulty = "Easy"
                }
            );
          
        }
    }
}
