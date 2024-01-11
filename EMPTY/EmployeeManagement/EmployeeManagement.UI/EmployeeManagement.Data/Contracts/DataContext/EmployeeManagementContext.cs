using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.Contracts.DataContext
{
    public class EmployeeManagementContext : IdentityDbContext<Employee>
    {
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {

        }

        public DbSet<EmployeeLeaveAllocation> EmployeeNewAllocations { get; set; }
        public DbSet<EmployeeLeaveRequest> EmployeeLeaveRequests { get; set; }
        public DbSet<EmployeeLeaveType> EmployeeLeaveTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeLeaveRequest>()
                .HasOne(e => e.RequestingEmployee)
                .WithMany()
                .HasForeignKey(e => e.RequestingEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeLeaveRequest>()
                .HasOne(e => e.ApprovedEmployee)
                .WithMany()
                .HasForeignKey(e => e.ApprovedEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
