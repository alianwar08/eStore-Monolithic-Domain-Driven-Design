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
    public class InventoryMangementAS
    {
        public AddProductResponse AddProduct(AddProductRequest request)
        {
            var response = new AddProductResponse();

            var gr = new GenericRepositery();
            try
            {
               var p = ProductDE.Create(
                    request.Name,
                    request.Barcode,
                    request.Description,
                    request.Category,
                    request.IsWeighted,
                    request.Status,
                    request.Price );

                gr.AddProduct(p);
                response.Product = p.Adapt<ProductDto>();
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

        public ChangeProductStatusResponse ChangeProductStatus(ChangeProductStatusRequest request)
        {
            var response = new ChangeProductStatusResponse();


            try
            {
                var gr = new GenericRepositery();
                gr.ChangeProductStatus(request.ProductId, request.NewStatus);
                response.IsSuccess = true;

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


        public GetProductResponse GetProduct(GetProductRequest request)
        {
            var response = new GetProductResponse();

            var gr = new GenericRepositery();
            try
            {
                var c = gr.GetProductByBarcode(request.Barcode);

                if (c != null)
                {
                    response.Product = c.Adapt<ProductDto>();
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
