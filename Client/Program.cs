using Client.Contracts;
using Client.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<,>), typeof(GeneralRepository<,>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IWorkReportRepository, WorkReportRepository>();
builder.Services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
builder.Services.AddScoped<IWorkOrderDetailRepository, WorkOrderDetailRepository>();
builder.Services.AddScoped<ICreateReportRepository, CreateReportRepository>();
builder.Services.AddScoped<ICreateWorkReportRepository, CreateWorkReportRepository>();
builder.Services.AddScoped<ICreateWorkOrderRepository, CreateWorkOrderRepository>();
builder.Services.AddScoped<IDetailReportRepository, DetailReportRepository>();
builder.Services.AddScoped<IEditReportRepository, EditReportRepository>();
builder.Services.AddScoped<ICsEmployeeRepository, CsEmployeeRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "login",
    pattern: "login",
    defaults: new { controller = "Home", action = "Login" }
);

app.Run();
