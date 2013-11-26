using System.Collections.Generic;

namespace quierobesarte.Models
{
    public class WeddingImageViewerDto
    {
        public List<WeddingImageDto> Images { get; set; }
        public string WeddingName { get; set; }
        public string WeddingId { get; set; }
    }
}