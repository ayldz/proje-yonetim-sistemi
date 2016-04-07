namespace ProjectMan.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class pmsEntity : DbContext
    {
        public pmsEntity()
            : base("name=pmsEntity")
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Milestone> Milestone { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Project)
                .WithRequired(e => e.Company1)
                .HasForeignKey(e => e.company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Milestone>()
                .HasMany(e => e.Task)
                .WithRequired(e => e.Milestone1)
                .HasForeignKey(e => e.milestone)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Milestone)
                .WithRequired(e => e.Project1)
                .HasForeignKey(e => e.project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Task)
                .WithRequired(e => e.Project1)
                .HasForeignKey(e => e.project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Project)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.projectmanager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Task)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.assingto)
                .WillCascadeOnDelete(false);
        }
    }
}
