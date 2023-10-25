using API.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Data;
public class HotlineCenterDbContext : DbContext
{
    public HotlineCenterDbContext(DbContextOptions<HotlineCenterDbContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<CsWorkOrder> CsWorkOders { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<WorkReport> WorkReports { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().HasIndex(e => e.Nik).IsUnique();
        modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
        modelBuilder.Entity<Employee>().HasIndex(e => e.PhoneNumber).IsUnique();

        //One Account Roles has many roles
        modelBuilder.Entity<AccountRole>()
            .HasOne(a => a.Account)
            .WithMany(a => a.AccountRoles)
            .HasForeignKey(a => a.AccountGuid);

        //One Role Has Many 
        modelBuilder.Entity<Role>()
            .HasMany(r => r.AccountRoles)
            .WithOne(a => a.Role)
            .HasForeignKey(r => r.RoleGuid);

        modelBuilder.Entity<Account>()
            .HasOne(a => a.Employee)
            .WithOne(e => e.Account)
            .HasForeignKey<Account>(a => a.Guid);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.CsTasks)
            .WithOne(cst => cst.Employee)
            .HasForeignKey(cst => cst.CsGuid);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Reports)
            .WithOne(r => r.Employee)
            .HasForeignKey(r => r.EmployeeGuid);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Report)
            .WithOne(r => r.Project)
            .HasForeignKey<Project>(p => p.ReportGuid);

        modelBuilder.Entity<Report>()
            .HasOne(r => r.WorkOrder)
            .WithOne(t => t.Report)
            .HasForeignKey<WorkOrder>(t => t.ReportGuid);

        modelBuilder.Entity<WorkReport>()
            .HasOne(wr => wr.WorkOrder)
            .WithOne(wo => wo.WorkReport)
            .HasForeignKey<WorkReport>(wr => wr.WorkOrderGuid);
        
        
        modelBuilder.Entity<Project>()
            .HasOne(p => p.WorkOrder)
            .WithOne(wo => wo.Project)
            .HasForeignKey<WorkOrder>(wo => wo.ProjectGuid);

        modelBuilder.Entity<CsWorkOrder>()
            .HasOne(ct => ct.WorkOrder)
            .WithMany(t => t.CsWorkOrders)
            .HasForeignKey(ct => ct.WorkOrderGuid)
            .OnDelete(DeleteBehavior.Restrict);

    }

}
