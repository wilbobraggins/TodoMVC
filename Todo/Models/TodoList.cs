using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Todo.Models
{
    public class TodoList
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Type { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Duration)]
        public decimal Hours { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(6)]
        public string Difficulty { get; set; }
    }

    public class TodoDBContext : DbContext
    {
        public DbSet<TodoList> Todos { get; set; }
    }
}