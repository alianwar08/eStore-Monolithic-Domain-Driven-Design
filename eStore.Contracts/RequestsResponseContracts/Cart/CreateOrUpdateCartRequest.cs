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


    public record CreateOrUpdateCartRequest : GenericRequest
    {
        public Guid CustomerId            { get; set; }
        public Guid[] ProductIds            { get; set; }
        public bool ClearCurrentItemsInCart            { get; set; }
    }   


    public record CreateOrUpdateCartResponse : GenericResponse
    {
        public CartDto Cart { get; set; }    

    }

}
