using Azure.Core;
using eStore.Core.Exceptions;
using eStore.Domain.Entities;
using eStore.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Infrastructure.Persistance
{
    public  class GenericRepositery
    {
        private InventoryDbContext _db = new InventoryDbContext();


        public async Task<CustomerDE> GetCustomer(Guid customerId)
        {
            var drCust = await (from n in _db.Customers   
                      where n.CustomerId == customerId
                      select n).FirstOrDefaultAsync();

            if (drCust == null)
                return null;
           

            var custDE = CustomerDE.Create(drCust.Name, drCust.Email, drCust.ShippingAddress, drCust.CustomerId);

            return custDE;

        }
        public async Task<CustomerDE> GetCustomerByEmail(string email)
        {
            var drCust = await (from n in _db.Customers
                          where n.Email == email
                          select n).FirstOrDefaultAsync();

            if (drCust == null)
                return null;


            var custDE = CustomerDE.Create(drCust.Name, drCust.Email, drCust.ShippingAddress, drCust.CustomerId);

            return custDE;

        }
        public async Task AddCustomer(CustomerDE customerDE)
        {
            _db.Customers.Add(new Infrastructure.Persistance.Repositories.Customer()
            {
              CustomerId = customerDE.CustomerId,
              Email= customerDE.Email,
              ShippingAddress = customerDE.ShippingAddress,
              Name= customerDE.Name
            });

            await _db.SaveChangesAsync();
        }


        public async Task AddProduct(ProductDE product)
        {
            _db.Products.Add(new Infrastructure.Persistance.Repositories.Product()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Barcode = product.Barcode,
                Category = product.Category,
                IsWeighted = product.IsWeighted,
                Status = (int)product.Status,
                Price = product.Price,
            });

            await _db.SaveChangesAsync();
        }
        public async Task ChangeProductStatus(Guid productId, ENUMS.ProductStatus newStatus)
        {
            var dr = await (from n in _db.Products
                      where n.ProductId == productId
                      select n).FirstOrDefaultAsync();

            if (dr == null)
                throw new BusinessRuleException("Product not found");

            dr.Status = (int)newStatus;

            await _db.SaveChangesAsync();


        }
        public async Task<ProductDE> GetProduct(Guid productId)
        {
            var dr = await (from n in _db.Products
                           where n.ProductId  == productId
                           select n).FirstOrDefaultAsync();

            if (dr == null)
                return null;

            var prdDE = ProductDE.Create(
                dr.Name,
                dr.Barcode,
                dr.Description,
                dr.Category,
                dr.IsWeighted.GetValueOrDefault(),
                (ENUMS.ProductStatus)dr.Status,
                dr.Price.GetValueOrDefault(),
                dr.ProductId);

            return prdDE;

        }
        public async Task<ProductDE> GetProductByBarcode(string barcode)
        {
            var dr = await (from n in _db.Products
                      where n.Barcode == barcode
                      select n).FirstOrDefaultAsync();

            if (dr == null)
                return null;

            var prdDE = ProductDE.Create(
                dr.Name,
                dr.Barcode,
                dr.Description,
                dr.Category,
                dr.IsWeighted.GetValueOrDefault(),
                (ENUMS.ProductStatus)dr.Status,
                dr.Price.GetValueOrDefault(),
                dr.ProductId);

            return prdDE;

        }
        
        
        public async Task<CartDE> GetCustomerCart(Guid customerId)
        {
            var dr = await (from n in _db.Carts
                      where n.CustomerID == customerId
                      select n).FirstOrDefaultAsync();

            if (dr == null)
                return null;

            var drCust = await (from n in _db.Customers
                          where n.CustomerId == dr.CustomerID
                          select n).FirstOrDefaultAsync();

            var drProductsIDs = (from n in _db.CartProducts
                                 where n.CartId == dr.CartId
                                 select n.ProductId);

            var drProducts = await (from n in _db.Products
                              where drProductsIDs.Contains(n.ProductId)
                              select n).ToArrayAsync();

            LinkedList<ProductDE> prds = new LinkedList<ProductDE>();

            foreach (var drP in drProducts)
            {
                var p = ProductDE.Create(
                   drP.Name,
                   drP.Barcode,
                   drP.Description,
                   drP.Category,
                   drP.IsWeighted.GetValueOrDefault(),
                   (ENUMS.ProductStatus)drP.Status,
                   drP.Price.GetValueOrDefault()
                   );

                prds.AddLast(p);
            }


            var custDE = CustomerDE.Create(drCust.Name, drCust.Email, drCust.ShippingAddress, drCust.CustomerId);
            var cartDE = new CartDE(custDE, dr.CartId, prds);


            return cartDE;

        }

        public async Task<CartDE> CreateOrUpdateCart(CartDE cart)
        {
            var drCart = await (from n in _db.Carts
                          where n.CartId == cart.CartId
                          select n).FirstOrDefaultAsync();

            if (drCart != null)
                throw new Exception("Code not implmented");


            drCart = new Cart()
            {
                CartId = cart.CartId,
                CustomerID = cart.Customer.CustomerId,
            };
            _db.Carts.Add(drCart);

            var drCust = await (from n in _db.Customers
                          where n.CustomerId == drCart.CustomerID
                          select n).FirstOrDefaultAsync();

            if (drCust == null)
                throw new Exception("Customer not found");

            foreach (var p in cart.Products)
            {
                var drCartProduct = new CartProduct()
                {
                    CartId = drCart.CartId,
                    ProductId = p.ProductId,
                };

                _db.CartProducts.Add(drCartProduct);
            }

            await _db.SaveChangesAsync();


            return await GetCustomerCart(cart.Customer.CustomerId);

        }

        public async Task ClearCart(Guid CartId)
        {
            var drCart = await (from n in _db.Carts
                          where n.CartId == CartId
                          select n).FirstOrDefaultAsync();

            if (drCart == null)
                throw new Exception("cart not found");


            var prds = (from n in _db.CartProducts
                        where n.CartId == drCart.CartId
                        select n);

            foreach (var p in prds)
            {
                _db.CartProducts.Remove(p);
            }

            await _db.SaveChangesAsync();

        }

        public async Task<InvoiceDE> CreateInvoice(InvoiceDE entity)
        {
            var drInvoice =await (from n in _db.Invoices
                          where n.InvoiceId == entity.InvoiceId
                          select n).FirstOrDefaultAsync();

            if (drInvoice != null)
                throw new Exception("Invoice already exsist");

            drInvoice = new Invoice()
            {
                InvoiceId= entity.InvoiceId,
                CreatedOn = entity.CreatedOn,
                CustomerId  = entity.InvoiceId,
                Status =  (int)entity.Status,
                TotalAmount = entity.TotalAmount
            };
            
            _db.Invoices.Add(drInvoice);

            await _db.SaveChangesAsync();

            return entity;

        }

    }
}
