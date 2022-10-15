using AWork.Contracts.Dto.Sales.SalesPerson;
using AWork.Contracts.Dto.Sales.ShoppingCartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction.Sales
{
    public interface IShoppingCartItemService
    {
        Task<IEnumerable<ShoppingCartItemDto>> GetAllShopCartItem(bool trackChanges);
        Task<ShoppingCartItemDto> GetShopCartItemById(int shopCartItemId, bool trackChanges);

        void Insert(ShoppingCartItemForCreateDto shopCartItemForCreateDto);

        void Edit(ShoppingCartItemDto shopCartItemDto);

        void Remove(ShoppingCartItemDto shopCartItemDto);
    }
}
