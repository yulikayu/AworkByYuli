using AWork.Contracts.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction.PersonModul
{
    public interface IBusinessEntityAddressServices
    {
        Task<IEnumerable<BusinessEntityAddressDto>> GetAllBusinessAddressContact(bool trackChanges);

        Task<BusinessEntityAddressDto> GetBusinessEntityAddressById(int businessEntityAddressId, bool trackChanges);

        void insert(BusinessEntityAddressForCreateDto businessEntityAddressForCreateDto);
        void edit(BusinessEntityAddressDto businessEntityAddressDto);
        void delete(BusinessEntityAddressDto businessEntityAddressDto);
    }
}
