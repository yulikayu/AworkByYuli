using System;

namespace AWork.Contracts.Dto.Production
{
    public class ProductSubCategoryForCreateDto
    {
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
