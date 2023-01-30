
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
    public class CustomerMangementAS
    {
        public AddCustomerResponse AddCustomer(AddCustomerRequest request)
        {
            var response = new AddCustomerResponse();

            var gr = new GenericRepositery();
            try
            {
                var p = CustomerDE.Create(
                     request.Name,
                     request.Email,
                     request.ShippingAddress);
                    

                gr.AddCustomer(p);
                response.Customer = p.Adapt<CustomerDto>();
                response.IsSuccess = true;

            }
            catch(CustomeException ex) {
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

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            var response = new GetCustomerResponse();

            var gr = new GenericRepositery();
            try
            {
                var c = gr.GetCustomerByEmail(request.Email);

                if (c != null)
                {
                    response.Customer = c.Adapt<CustomerDto>();
                    response.IsSuccess = true;
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

    }
}
