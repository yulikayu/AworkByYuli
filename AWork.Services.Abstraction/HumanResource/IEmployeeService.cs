using AWork.Contracts.Dto.HumanResources.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction.HumanResource
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployee(bool trackChanges);

        Task<EmployeeDto> GetEmployeeDtoById(int BusinessEntityId, bool trackChange);
        void Insert(EmployeeForCreateDto employee);
        void Edit(EmployeeDto employee);
        void Remove(EmployeeDto employee);
    }
}
