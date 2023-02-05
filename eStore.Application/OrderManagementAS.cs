global using Mapster;
using Azure;
using Azure.Core;
using eStore.Contracts;
using eStore.Contracts.DTOs;
using eStore.Core.Exceptions;
using eStore.Domain.Entities;
using eStore.Infrastructure.Persistance;
using eStore.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eStore.Application
{
    public class OrderManagementAS
    {

        public async Task<GetCartResponse> GetCart(GetCartRequest request)
        {
            var response = new GetCartResponse();

            var gr = new GenericRepositery();
            try
            {
                var cartDE = await gr.GetCustomerCart(request.CustomerId);

                if (cartDE == null)
                {
                    response.Cart = null;
                }
                else
                {
                    response.IsSuccess = true;
                    response.Cart = cartDE.Adapt<CartDto>();
                }

            }
            catch (CustomeException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //TODO: Log error
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Internal Server error";
                //TODO: Log error
            }

            return response;
        }

        public async Task<CreateOrUpdateCartResponse> CreateOrUpdateCart(CreateOrUpdateCartRequest request)
        {
            var response = new CreateOrUpdateCartResponse();

            var gr = new GenericRepositery();
            try
            {
                var cartDE = await gr.GetCustomerCart(request.CustomerId);


                if (cartDE == null)
                {
                    var custDE = await gr.GetCustomer(request.CustomerId);
                    if (custDE == null)
                    {
                        throw new BusinessRuleException("Customer not found");
                    }

                    cartDE = new CartDE(custDE, null, null);
                }

                foreach (var drPrdID in request.ProductIds)
                {
                    var drPrdDE = await gr.GetProduct(drPrdID);

                    cartDE.AddProduct(drPrdDE);
                }

                var c = await gr.CreateOrUpdateCart(cartDE);

                response.Cart = c.Adapt<CartDto>();
                response.IsSuccess = true;
                response.Cart = cartDE.Adapt<CartDto>();

            }
            catch (CustomeException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //TODO: Log error
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Internal Server error";
                //TODO: Log error
            }

            return response;
        }

        public async Task<CheckOutCartResponse> CheckOutCart(CheckOutCartRequest request)
        {
            var response = new CheckOutCartResponse();

            var gr = new GenericRepositery();
            try
            {
                var cartDE = await gr.GetCustomerCart(request.CustomerId);

                if (cartDE == null)              
                   throw new BusinessRuleException("Cart or customer not found");

                var invoiceDE = cartDE.CreateOrder();

                await gr.CreateInvoice(invoiceDE);

                response.CustomerId = cartDE.Customer.CustomerId;
                response.Invoice = invoiceDE.Adapt<InvoiceDto>();
                response.IsSuccess = true;

                try
                {
                    await gr.ClearCart(cartDE.CartId);
                }
                catch (Exception ee)
                {
                    
                    response.Message = "Order created. However unable to clear cart";
                    //TODO: Log error
                }

            }
            catch (CustomeException ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                //TODO: Log error
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Internal Server error";
                //TODO: Log error
            }

            return response;
        }

        //public ChangeProductStatusResponse ChangeProductStatus(ChangeProductStatusRequest request)
        //{
        //    var response = new ChangeProductStatusResponse();

        //    try
        //    {
        //        var gr = new GenericRepositery();
        //        gr.ChangeProductStatus(request.ProductId, request.NewStatus);
        //        response.IsSuccess = true;

        //    }
        //    catch (CustomeException ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = ex.Message;
        //        //TODO: Log error
        //    }
        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = "Internal Server error";
        //        //TODO: Log error
        //    }

        //    return response;
        //}
    }
}
