using AutoMapper;
using AWork.Contracts.Dto.Sales.ShoppingCartItem;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.Sales
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly ISalesRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ShoppingCartItemService(ISalesRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(ShoppingCartItemDto shopCartItemDto)
        {
            var editData = _mapper.Map<ShoppingCartItem>(shopCartItemDto);
            _repositoryManager.ShoppingCartItemRepository.Edit(editData);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ShoppingCartItemDto>> GetAllShopCartItem(bool trackChanges)
        {
            var shopCartItemModel = await _repositoryManager.ShoppingCartItemRepository.GetAllShoppingCartItem(trackChanges);
            var shopCartItemDto = _mapper.Map<IEnumerable<ShoppingCartItemDto>>(shopCartItemModel);
            return shopCartItemDto;
        }

        public async Task<ShoppingCartItemDto> GetShopCartItemById(int shopCartItemId, bool trackChanges)
        {
            var shopCartItemModel = await _repositoryManager.ShoppingCartItemRepository.GetShoppingCartItemById(shopCartItemId,trackChanges);
            var shopCartItemDto = _mapper.Map<ShoppingCartItemDto>(shopCartItemModel);
            return shopCartItemDto;
        }

        public void Insert(ShoppingCartItemForCreateDto shopCartItemForCreateDto)
        {
            var insertData = _mapper.Map<ShoppingCartItem>(shopCartItemForCreateDto);
            _repositoryManager.ShoppingCartItemRepository.Insert(insertData);
            _repositoryManager.Save();
        }

        public void Remove(ShoppingCartItemDto shopCartItemDto)
        {
            var removeData = _mapper.Map<ShoppingCartItem>(shopCartItemDto);
            _repositoryManager.ShoppingCartItemRepository.Remove(removeData);
            _repositoryManager.Save();
        }
    }
}
