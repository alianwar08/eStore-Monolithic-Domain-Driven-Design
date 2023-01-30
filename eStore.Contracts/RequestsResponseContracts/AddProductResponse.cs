using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENUMS;
using eStore.Contracts;
using eStore.Contracts.DTOs;

namespace eStore.Contracts
{
    public record AddProductRequest : GenericRequest
    {
        public string Name               { get; set; }
        public string Barcode            { get; set; }
        public string Description        { get; set; }
        public string Category           { get; set; }
        public bool  IsWeighted          { get; set; }
        public ProductStatus Status      { get; set; }
        public decimal Price             { get; set; }
    }


    public record AddProductResponse : GenericResponse
    {
        public ProductDto Product { get; set; }
        
    }

}
