using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Infrastructure.Persistance.Repositories
{
    public class Customer
    {
        public Customer(){}

        [Key]
        [MaxLength(50)]
        public Guid   CustomerId       { get; set; }
        public string Name             { get; set; }
        public string Email            { get; set; }
        public string? ShippingAddress  { get; set; }

    }


}
