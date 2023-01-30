using ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Contracts.DTOs
{
    public record ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsWeighted { get; set; }
        public ProductStatus Status { get; set; }
        public decimal Price { get; set; }
    }
}
