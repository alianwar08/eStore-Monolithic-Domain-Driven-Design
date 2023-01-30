using ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Contracts.DTOs
{
    public record CustomerDto
    {
        public Guid CustomerId { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string ShippingAddress { get;  set; }
    }
}
