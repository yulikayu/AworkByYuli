using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Contracts.Dto.Production
{
    public class UploadImages
    {
        public IFormFile FileImages { get; set; }
        public virtual ProductPhotoDto ProductPhoto { get; set; }

    }
}
