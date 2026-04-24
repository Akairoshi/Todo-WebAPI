using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteModel>().HasKey(x => x.Id);
            modelBuilder.Entity<NoteModel>().Property(x => x.Name).HasMaxLength(60);
            modelBuilder.Entity<NoteModel>().Property(x => x.Text).HasMaxLength(140);

            modelBuilder.Entity<TaskModel>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskModel>().Property(x => x.Name).HasMaxLength(60);
            modelBuilder.Entity<TaskModel>().Property(x => x.Description).HasMaxLength(140);


            base.OnModelCreating(modelBuilder);
        }
    }
}