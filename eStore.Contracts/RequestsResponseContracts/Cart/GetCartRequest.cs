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


    public record GetCartRequest : GenericRequest
    {
        public Guid CustomerId            { get; set; }
      
    }   


    public record GetCartResponse : GenericResponse
    {
        public CartDto Cart { get; set; }    

    }

}
