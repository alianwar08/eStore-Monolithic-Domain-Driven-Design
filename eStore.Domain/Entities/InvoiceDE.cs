using eStore.Core.Exceptions;
using ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Domain.Entities
{
    public class InvoiceDE
    {
        private InvoiceDE()
        { 

        }

        public Guid InvoiceId     { get; private set; }
        public CustomerDE Customer        { get; private set; }
        public List<ProductDE> Products { get; private set; }

        public decimal TotalAmount     { get; private set; }
        public InvoiceStatus Status      { get; private set; }
        public DateTime CreatedOn { get; private set; }





        public static InvoiceDE Create(CartDE cart)
        {

            if (cart.Products.Count()==0)
                throw new BusinessRuleException("Cart can not be empty.");

            if (cart.Customer == null)
                throw new BusinessRuleException("Cart must have a valid customer");

            var c = new InvoiceDE();
            c.InvoiceId = Guid.NewGuid();
            c.Products = cart.Products;
            c.TotalAmount = cart.Products.Sum(a => a.Price);
            c.Status = InvoiceStatus.Pending;
            c.CreatedOn = DateTime.UtcNow;

            return c;
        }

    }


}
