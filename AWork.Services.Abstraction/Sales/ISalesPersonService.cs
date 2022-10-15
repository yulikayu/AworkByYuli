using AWork.Contracts.Dto.Sales.SalesPerson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction.Sales
{
    public interface ISalesPersonService
    {
        Task<IEnumerable<SalesPersonDto>> GetAllSalesPerson(bool trackChanges);
        Task<SalesPersonDto> GetSalesPersonById(int bussinessEntityId, bool trackChanges);

        void Insert(SalesPersonForCreateDto salesPersonForCreateDto);

        void Edit(SalesPersonDto salesPersonDto);

        void Remove(SalesPersonDto salesPersonDto);
    }
}
