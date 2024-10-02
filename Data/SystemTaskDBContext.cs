using Microsoft.EntityFrameworkCore;
using WebApi.Data.Map;
using WebApi.Models;

namespace WebApi.Data
{
    public class SystemTaskDBContext(DbContextOptions<SystemTaskDBContext> options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}