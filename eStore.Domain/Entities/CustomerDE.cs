using eStore.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Domain.Entities
{
    public class CustomerDE
    {
        private CustomerDE(){}

        public Guid CustomerId { get; private set; }
        public string Name    { get; private set; }
        public string Email   { get; private set; }
        public string ShippingAddress { get; private set; }

        public static CustomerDE Create(string name, string email, string shippingAddress,Guid? customerId=null)
        {
          
            if (string.IsNullOrWhiteSpace(email))
                throw new BusinessRuleException("Customer email cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException("Customer name cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(shippingAddress))
                throw new BusinessRuleException("Customer shipping address cannot be null or whitespace.");

            if (customerId == null) customerId = Guid.NewGuid();
            return new CustomerDE() { CustomerId= customerId.Value, Email =email, Name= name ,  ShippingAddress=shippingAddress };
        }

        public  void Update(string name, string email, string shippingAddress)
        {

            if (string.IsNullOrWhiteSpace(email))
                throw new BusinessRuleException("Customer email cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException("Customer name cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(shippingAddress))
                throw new BusinessRuleException("Customer shipping address cannot be null or whitespace.");


            this.Email = email; ;
            this.ShippingAddress = shippingAddress; 
            this.Name=  name;
         }

    }


}
