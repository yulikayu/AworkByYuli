using AutoMapper;
using AWork.Contracts.Dto.Production;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.Production
{
    public class ProductService : IProductService
    {
        private IProductionRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
       
        public ProductService(IProductionRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetAllProduct(trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);

            return productDto;

        }

        public async Task<ProductDto> GetProductById(int ProductId, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductById(ProductId, trackChanges);
            var productDto = _mapper.Map<ProductDto>(productModel);

            return productDto;
        }

        public void Insert(ProductForCreateDto productForCreateDto)
        {
            var productModel = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productModel);
            _repositoryManager.Save();
        }

        public void Remove(ProductDto productDto)
        {
            var productModel = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Remove(productModel);
            _repositoryManager.Save();
        }
        public void Edit(ProductDto productDto)
        {
            var productModel = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Edit(productModel);
            _repositoryManager.Save();
        }

        public ProductDto CreateProductId()
        {
            var product = new Product
            {
                ModifiedDate = DateTime.Now
            };
            _repositoryManager.ProductRepository.Insert(product);
            _repositoryManager.Save();
            var product_Dto = _mapper.Map<ProductDto>(product);
            return product_Dto;
        }
    }
}
