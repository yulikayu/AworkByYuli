﻿using System;
namespace AWork.Contracts.Dto
{
    public class AddressTypeDto
    {
        public int AddressTypeId { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
