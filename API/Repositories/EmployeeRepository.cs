﻿using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(HotlineCenterDbContext context) : base(context) { }

}