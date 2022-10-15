using AWork.Contracts.Dto.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction.Purchasing
{
    public interface IPurchaseOrderDetailService
    {
        Task<IEnumerable<PurchaseOrderDetailsDto>> GetAllPurchaseOD(bool trackChanges);

        Task<PurchaseOrderDetailsDto> GetPurchaseODById(int purchaseOHId, bool trackChanges);

        void Insert(PurchaseOrderDetailsForCreateDto purchaseOrderDetailsForCreateDto);

        void Edit(PurchaseOrderDetailsDto purchaseOrderDetailsDto);

        void Remove(PurchaseOrderDetailsDto purchaseOrderDetailsDto);
    }
}
