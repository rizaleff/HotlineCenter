using API.Models;
using Microsoft.EntityFrameworkCore;
using WorkOrder = API.Models.WorkOrder;

namespace API.Data;
public class HotlineCenterDbContext : DbContext
{
    public HotlineCenterDbContext(DbContextOptions<HotlineCenterDbContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<CsTask> CsTasks { get; set; }
    public DbSet<Division> Divisions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Projects> Projects { get; set; }
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
            .HasOne(d => d.Division)
            .WithMany(e => e.Employees)
            .HasForeignKey(e => e.DivisionGuid);

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
            .HasOne(tr => tr.WorkOrder)
            .WithOne(t => t.WorkReport)
            .HasForeignKey<WorkReport>(tr => tr.Guid);

        modelBuilder.Entity<CsTask>()
            .HasOne(ct => ct.Task)
            .WithMany(t => t.CsTasks)
            .HasForeignKey(ct => ct.WorkOrderGuid)
            .OnDelete(DeleteBehavior.Restrict);

    }

}
