using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BigSchool.Models
{
    public partial class BigSchoolContent : DbContext
    {
        public BigSchoolContent()
            : base("name=BigSchoolContent")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Course)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
        }
    }
}
