using System;

namespace quierobesarte.Models
{
    public class ImageDto
    {
        public string originalPath { get; set; }
        public string thumbnailPath { get; set; }
        public DateTime created { get; set; }
        public decimal id { get; set; }
    }
}
