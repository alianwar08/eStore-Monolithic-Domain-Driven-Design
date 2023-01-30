using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Domain.Entities
{
    public class CartDE
    {
        public CartDE(CustomerDE customer , Guid? cartId =null, IEnumerable<ProductDE> products=null)
        {
            Products = new List<ProductDE>();
            Customer = customer;
            if (cartId == null) cartId = Guid.NewGuid();
            CartId = cartId.Value;
            if (products != null)
            {
                Products.AddRange(products);
            }
        }


        public Guid CartId { get; private set; }
        public List<ProductDE> Products { get; private set; }
        public CustomerDE Customer { get; private set; } = null!;
        public InvoiceDE  Invoice { get; private set; } = null!;



        public void AddProduct(ProductDE product)
        {
            RemoveProductIfAny(product.ProductId);
            Products.Add(product);
        }

        public void RemoveProduct(ProductDE product)
        {
            Products.Remove(product);
        }

        public void RemoveProductIfAny(Guid productId)
        {
            var c = Products.Where(o => o.ProductId == productId).FirstOrDefault();
            if (c != null)            
                this.RemoveProduct(c);
        }


        public InvoiceDE CreateOrder()
        {
            Invoice = InvoiceDE.Create(this);
            return Invoice;
        }


    }


}
