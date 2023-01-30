using eStore.Contracts;
using eStore.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Contracts
{ 
    public record AddCustomerRequest : GenericRequest
    {
        public string Name            { get; set; }
        public string Email           { get; set; }
        public string ShippingAddress { get; set; }

    }


    public record AddCustomerResponse : GenericResponse
    {
        public CustomerDto Customer { get; set; }       

    }


}
