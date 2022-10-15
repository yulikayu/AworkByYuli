using AWork.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Domain.Repositories.Sales
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomer(bool trackChanges);

        Task<Customer> GetCustomerById(int customerId, bool trackChanges);

        void Insert(Customer customer);

        void Edit(Customer customer);

        void Remove(Customer customer);
    }
}
