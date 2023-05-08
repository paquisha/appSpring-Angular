using ADReporting.Entities;
using Microsoft.EntityFrameworkCore;

namespace ADReporting
{
    public class ReportingToolContext : DbContext
    {
        
        public ReportingToolContext(DbContextOptions<ReportingToolContext> options)
        : base(options) { }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AttentionSchedule> AttentionSchedules { get; set; }
        public DbSet<ContactUser> ContactUsers { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>().ToTable("Alert");
            modelBuilder.Entity<Notification>().ToTable("Notification");
            modelBuilder.Entity<AttentionSchedule>().ToTable("AttentionSchedule");
            modelBuilder.Entity<ContactUser>().ToTable("ContactUser");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Department>().ToTable("Department");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-V1IICF3\\SQLEXPRESS;Initial Catalog=PersonDatabase;Integrated Security=True");
            }
        }
    }
}