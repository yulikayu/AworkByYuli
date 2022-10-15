using AWork.Domain.Models;
using System;
using System.Collections.Generic;

namespace AWork.Contracts.Dto.Production
{
    public class ProductSubCategoryDto
    {
        public int ProductSubcategoryId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }


        public virtual ProductCategoryDto ProductCategory { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; }

    }
}
