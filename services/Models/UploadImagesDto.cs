using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace quierobesarte.Models
{
    public class UploadImagesDto
    {
        public bool IsAdmin { get; set; }    
        public string WeddingName { get; set; }
        public bool IsWeddingActive { get; set; }
    }
}