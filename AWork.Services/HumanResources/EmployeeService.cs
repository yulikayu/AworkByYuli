using AutoMapper;
using AWork.Contracts.Dto.HumanResources.Employee;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.HumanResource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.HumanResources
{
    public class EmployeeService : IEmployeeService
    {
        // ======= depedency injectorr ========== ///

        private readonly IHRRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EmployeeService(IHRRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            this._mapper = mapper;
        }

        // ========================================= //

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployee(bool trackChanges)
        {
            var employeeModel = await _repositoryManager.EmployeeRepository.GetAllEmployee(trackChanges);
            // source = categoryModel, target categoryDto
            var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeeModel);
            return employeeDto;
        }

        public async Task<EmployeeDto> GetEmployeeDtoById(int BusinessEntityId, bool trackChange)
        {
            var employeeModel = await _repositoryManager.EmployeeRepository.GetEmployeeById(BusinessEntityId, trackChange);
            // source = categoryModel, target categoryDto
            var employeeDto = _mapper.Map<EmployeeDto>(employeeModel);
            return employeeDto;
        }

        public void Insert(EmployeeForCreateDto employee)
        {
            var employeeIn = _mapper.Map<Employee>(employee);
            _repositoryManager.EmployeeRepository.Insert(employeeIn);
            _repositoryManager.Save();
        }

        public void Remove(EmployeeDto employee)
        {
            var employeeModel = _mapper.Map<Employee>(employee);
            _repositoryManager.EmployeeRepository.Remove(employeeModel);
            _repositoryManager.Save();
        }

        public void Edit(EmployeeDto employee)
        {
            var employeeModel = _mapper.Map<Employee>(employee);
            _repositoryManager.EmployeeRepository.Edit(employeeModel);
            _repositoryManager.Save();
        }
    }
}
