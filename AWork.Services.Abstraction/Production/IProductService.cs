using AWork.Contracts.Dto.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges);
        Task<ProductDto> GetProductById(int UnitMeasureCode, bool trackChanges);
        ProductDto CreateProductId();
        void Insert(ProductForCreateDto productForCreateDto);
        void Edit(ProductDto productDto);
        void Remove(ProductDto productDto);

    }
}
