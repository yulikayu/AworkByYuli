using AWork.Domain.Models;
using System;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Contracts.Dto.Production
{
    public class ProductDto
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool? MakeFlag { get; set; }
        public bool? FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public int? ProductModelId { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ProductModel ProductModel { get; set; }
        public virtual ProductSubCategoryDto ProductSubcategory { get; set; }
        public virtual UnitMeasure SizeUnitMeasureCodeNavigation { get; set; }
        public virtual UnitMeasure WeightUnitMeasureCodeNavigation { get; set; }
        public virtual ICollection<BillOfMaterial> BillOfMaterialComponents { get; set; }
        public virtual ICollection<BillOfMaterial> BillOfMaterialProductAssemblies { get; set; }
        public virtual ICollection<ProductCostHistory> ProductCostHistories { get; set; }
        public virtual ICollection<ProductInventoryDto> ProductInventories { get; set; }
        public virtual ICollection<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        public virtual ICollection<ProductProductPhotoDto> ProductProductPhotos { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        public virtual ICollection<TransactionHistoryDto> TransactionHistories { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
