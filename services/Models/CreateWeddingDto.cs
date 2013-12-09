using System;
using System.Collections.Generic;

namespace quierobesarte.Models
{
    public class AdminDto : IAuthentication
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        public string CurrentQrCodeImageName { get; set; }
        public List<WeddingDto> Weddings { get; set; }
        public bool WeddingCreated { get; set; }
        public bool IsAdmin { get; set; }

  
    }
}
