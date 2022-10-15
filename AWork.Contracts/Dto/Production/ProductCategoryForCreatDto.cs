using System;

namespace AWork.Contracts.Dto.Production
{
    public class ProductCategoryForCreatDto
    {
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
