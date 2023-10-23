using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class TaskReportRepository : GeneralRepository<TaskReport>, ITaskReportRepository
{
    public TaskReportRepository(HotlineCenterDbContext context) : base(context) { }
}