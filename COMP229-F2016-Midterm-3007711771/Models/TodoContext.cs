namespace COMP229_F2016_Midterm_3007711771.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TodoContext : DbContext
    {
        public TodoContext()
            : base("name=TodoConnection")
        {
        }

        public virtual DbSet<Todos> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
