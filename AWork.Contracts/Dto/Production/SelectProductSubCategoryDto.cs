using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Contracts.Dto.Production
{
    public class SelectProductSubCategoryDto
    {
       public ProductCategoryDto ProductCategoryDto { get; set; }
       public ProductSubCategoryDto  ProductSubCategoryDto { get; set; }
    }
}
