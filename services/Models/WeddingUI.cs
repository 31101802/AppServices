using System;

namespace quierobesarte.Models
{
    public class WeddingDto
    {
        public string Id { get; set; }
        public string Name{ get; set; }
        public string Date { get; set; }

        public string QrCodeImageName { get; set; }

        public bool IsActive { get; set; }
    }
}
