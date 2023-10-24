using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class WorkReportRepository : GeneralRepository<WorkReport>, IWorkReportRepository
{
    public WorkReportRepository(HotlineCenterDbContext context) : base(context) { }
}