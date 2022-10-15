using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AWork.Contracts.Dto.Production
{
    public class ProductPhotoForCreateDto
    {
        //public byte[] ThumbNailPhoto { get; set; }
        public List<IFormFile> FilePhoto { get; set; }

        //public byte[] LargePhoto { get; set; }
        public string LargePhotoFileName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
