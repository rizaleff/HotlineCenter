using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class TaskRepository : GeneralRepository<Models.Task>, ITaskRepository
{
    public TaskRepository(HotlineCenterDbContext context) : base(context) { }

}