using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class ProjectRepository : GeneralRepository<Project>, IProjectRepository
{
    public ProjectRepository(HotlineCenterDbContext context) : base(context) { }

}