using AWork.Contracts.Dto.Sales.SalesOfferProduct;
using AWork.Contracts.Dto.Sales.SpecialOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction.Sales
{
    public interface ISpecialOfferService
    {
        Task<IEnumerable<SpecialOfferDto>> GetAllSpecialOffer(bool trackChanges);
        Task<SpecialOfferDto> GetSpecialOfferById(int productId, bool trackChanges);

        SpecialOfferDto CreateSpecialOfferProduct(SpecialOfferForCreateDto specialOfferForCreateDto);


        void Insert(SpecialOfferForCreateDto specialOfferrForCreateDto);

        void Edit(SpecialOfferDto specialOfferDto);

        void Remove(SpecialOfferDto specialOfferDto);
    }
}
