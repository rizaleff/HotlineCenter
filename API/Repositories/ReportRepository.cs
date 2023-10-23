using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class ReportRepository : GeneralRepository<Report>, IReportRepository
{
    public ReportRepository(HotlineCenterDbContext context) : base(context) { }

}