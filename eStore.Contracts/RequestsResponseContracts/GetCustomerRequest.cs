using eStore.Contracts;
using eStore.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Contracts
{ 
    public record GetCustomerRequest : GenericRequest
    {
        public string Email           { get; set; }
    }


    public record GetCustomerResponse : GenericResponse
    {
        public CustomerDto Customer { get; set; }
    }

}
