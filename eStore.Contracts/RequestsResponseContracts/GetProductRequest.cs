using eStore.Contracts;
using eStore.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Contracts
{ 
    public record GetProductRequest : GenericRequest
    {
        public string Barcode           { get; set; }
    }


    public record GetProductResponse : GenericResponse
    {
        public ProductDto Product { get; set; }
    }

}
