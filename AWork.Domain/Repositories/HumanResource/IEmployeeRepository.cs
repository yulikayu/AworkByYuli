using AWork.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Domain.Repositories.HumanResource
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployee(bool trackChanges);

        Task<Employee> GetEmployeeById(int BusinessEntityId, bool trackChange);
        void Insert(Employee employee);
        void Edit(Employee employee);
        void Remove(Employee employee);
    }
}
