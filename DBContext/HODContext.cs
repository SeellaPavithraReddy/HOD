using HODPoc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HODPoc.DBContext
{
    public class HODContext : DbContext
    {
        public HODContext(DbContextOptions<HODContext> options)
            : base(options) { }

        public DbSet<Student> students { set; get; }
        public DbSet<Subject> subjects { set; get; }
        public DbSet<Teacher> teachers { set; get; }
        public DbSet<Hod> hods { set; get; }
        public DbSet<Login> logins { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(e => e.sId).ValueGeneratedNever();
            modelBuilder.Entity<Subject>().Property(e => e.suId).ValueGeneratedNever();
            modelBuilder.Entity<Hod>().Property(e => e.hodId).ValueGeneratedNever();
            modelBuilder.Entity<Teacher>().Property(e => e.tId).ValueGeneratedNever();
            modelBuilder.Entity<Login>().Property(e => e.username).ValueGeneratedNever();
        }
    }
}
