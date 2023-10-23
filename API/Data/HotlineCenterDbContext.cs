using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
public class HotlineCenterDbContext : DbContext
{
    public HotlineCenterDbContext(DbContextOptions<HotlineCenterDbContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<CsTask> CsTasks { get; set; }
    public DbSet<Division> Divisions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<TaskReport> TaskReports { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }

}
