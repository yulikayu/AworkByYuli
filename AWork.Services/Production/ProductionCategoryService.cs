using AutoMapper;
using AWork.Contracts.Dto.Production;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.Production;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.Production
{
    internal class ProductionCategoryService : IProductCategoryService
    {
        private IProductionRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductionCategoryService(IProductionRepositoryManager productionRepositoryManager, IMapper mapper)
        {
            _repositoryManager = productionRepositoryManager;
            _mapper = mapper;
        }

        public void Edit(ProductCategoryDto productCategoryDto)
        {
            var productCateModel = _mapper.Map<ProductCategory>(productCategoryDto);
            _repositoryManager.ProductCategoryRepository.edit(productCateModel);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetAllProdcCategory(bool trackChanges)
        {
            var procdCategory = await _repositoryManager.ProductCategoryRepository.GetAllProdcCategory(trackChanges);
            var prodcCategoryDto = _mapper.Map<IEnumerable<ProductCategoryDto>>(procdCategory);
            return prodcCategoryDto;
        }

        public async Task<ProductCategoryDto> GetProcdCateById(int prodcCategory, bool trackChanges)
        {
            var productCateModel = await _repositoryManager.ProductCategoryRepository.GetProcdCateById(prodcCategory, trackChanges);
            var productCateDto = _mapper.Map<ProductCategoryDto>(productCateModel);
            return productCateDto;
        }

        public void Insert(ProductCategoryForCreatDto productCategoryForCreat)
        {
            var productCateModel = _mapper.Map<ProductCategory>(productCategoryForCreat);
            _repositoryManager.ProductCategoryRepository.insert(productCateModel);
            _repositoryManager.Save();
        }

        public void Remove(ProductCategoryDto productCategoryDto)
        {
            var productCateModel = _mapper.Map<ProductCategory>(productCategoryDto);
            _repositoryManager.ProductCategoryRepository.remove(productCateModel);
            _repositoryManager.Save();
        }
    }
}
