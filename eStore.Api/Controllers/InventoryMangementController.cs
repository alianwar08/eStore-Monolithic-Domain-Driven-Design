using Azure.Core;
using eStore.Application;
using eStore.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryMangementController : ControllerBase
    {
        private readonly ILogger<InventoryMangementController> _logger;

        public InventoryMangementController(ILogger<InventoryMangementController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost("GetProduct")]
        public GetProductResponse GetProduct(GetProductRequest request)
        {
            GetProductResponse response;
            try
            {
                var IM = new InventoryMangementAS();
                response = IM.GetProduct(request);
                return response;
            }

            catch(Exception ex)
            {
                var EventID = Math.Abs (Guid.NewGuid().GetHashCode());
                _logger.LogError(new EventId(EventID), ex, "App server return with exception", request);
                response = new GetProductResponse() { IsSuccess = false, Message = "Internal server error: EventID:"+ EventID };
                return response;
            }
            

        }

        [HttpPost("AddProduct")]
        public AddProductResponse AddProduct(AddProductRequest request)
        {
            AddProductResponse response;
            try
            {
                var IM = new InventoryMangementAS();
                response = IM.AddProduct(request);
                return response;
            }
            catch (Exception ex)
            {
                var EventID = Math.Abs(Guid.NewGuid().GetHashCode());
                _logger.LogError(new EventId(EventID), ex, "App server return with exception", request);
                response = new AddProductResponse() { IsSuccess = false, Message = "Internal server error: EventID:" + EventID };
                return response;
            }


        }


        [HttpPost("ChangeProductStatus")]
        public ChangeProductStatusResponse ChangeProductStatus(ChangeProductStatusRequest request)
        {
            ChangeProductStatusResponse response;
            try
            {
                var IM = new InventoryMangementAS();
                response = IM.ChangeProductStatus(request);
                return response;
            }

            catch (Exception ex)
            {
                var EventID = Math.Abs(Guid.NewGuid().GetHashCode());
                _logger.LogError(new EventId(EventID), ex, "App server return with exception", request);
                response = new ChangeProductStatusResponse() { IsSuccess = false, Message = "Internal server error: EventID:" + EventID };
                return response;
            }


        }
    }




}