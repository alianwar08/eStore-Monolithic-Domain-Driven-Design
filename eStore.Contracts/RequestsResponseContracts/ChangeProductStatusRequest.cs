using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENUMS;
using eStore.Contracts;

namespace eStore.Contracts
{
    public record ChangeProductStatusRequest : GenericRequest
    {
        public Guid ProductId { get; set; }
        public ProductStatus NewStatus      { get; set; }
    }


    public record ChangeProductStatusResponse : GenericResponse
    {
        public Guid ProductId { get; set; }       
        public ProductStatus Status { get; set; }
    }

}
