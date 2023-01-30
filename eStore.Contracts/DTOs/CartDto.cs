using ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Contracts.DTOs
{
    public record CartDto
    {
        public Guid CartId { get; set; }
        public List<ProductDto> Products { get; set; }
        public CustomerDto Customer { get; set; }
        public InvoiceDto Invoice { get; set; }
    }
}
