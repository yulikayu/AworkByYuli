using AWork.Domain.Models;
using AWork.Domain.Repositories.HumanResource;
using AWork.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Persistence.Repositories.HumanResource
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        private short departmentId;
        //By Widi
        public DepartmentRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(Department department)
        {
            Update(department);
        }

        public async Task<IEnumerable<Department>> GetAllDepartment(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id, bool trackChanges)
        {
            return await FindByCondition(d => d.DepartmentId.Equals(departmentId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(Department department)
        {
            Create(department);
        }

        public void Remove(Department department)
        {
            Delete(department);
        }
    }
}
