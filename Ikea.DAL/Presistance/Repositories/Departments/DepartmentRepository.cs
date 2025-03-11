﻿using Ikea.DAL.Models.Departments;
using Ikea.DAL.Presistance.Data;
using Ikea.DAL.Presistance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.DAL.Presistance.Repositories.Departments
{
    public class DepartmentRepository :GenericRepository<Department>  ,IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
