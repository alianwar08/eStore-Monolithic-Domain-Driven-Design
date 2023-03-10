using Azure.Core;
using eStore.Application;
using eStore.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderManagementController : ControllerBase
    {
        private readonly ILogger<OrderManagementController> _logger;

        public OrderManagementController(ILogger<OrderManagementController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost("GetCart")]
        public async Task<GetCartResponse> GetCart(GetCartRequest request)
        {
            GetCartResponse response;
            try
            {
                var IM = new OrderManagementAS();
                response = await IM.GetCart(request);
                return response;
            }

            catch(Exception ex)
            {
                var EventID = Math.Abs (Guid.NewGuid().GetHashCode());
                _logger.LogError(new EventId(EventID), ex, "App server return with exception", request);
                response = new GetCartResponse() { IsSuccess = false, Message = "Internal server error: EventID:"+ EventID };
                return response;
            }
            

        }

        [HttpPost("CreateOrUpdateCart")]
        public async Task<CreateOrUpdateCartResponse> CreateOrUpdateCart(CreateOrUpdateCartRequest request)
        {
            CreateOrUpdateCartResponse response;
            try
            {
                var IM = new OrderManagementAS();
                response = await IM.CreateOrUpdateCart(request);
                return response;
            }

            catch (Exception ex)
            {
                var EventID = Math.Abs(Guid.NewGuid().GetHashCode());
                _logger.LogError(new EventId(EventID), ex, "App server return with exception", request);
                response = new CreateOrUpdateCartResponse() { IsSuccess = false, Message = "Internal server error: EventID:" + EventID };
                return response;
            }


        }

        [HttpPost("CheckOutCart")]
        public async Task<CheckOutCartResponse> CheckOutCart(CheckOutCartRequest request)
        {
            CheckOutCartResponse response;
            try
            {
                var IM = new OrderManagementAS();
                response = await IM.CheckOutCart(request);
                return response;
            }

            catch (Exception ex)
            {
                var EventID = Math.Abs(Guid.NewGuid().GetHashCode());
                _logger.LogError(new EventId(EventID), ex, "App server return with exception", request);
                response = new CheckOutCartResponse() { IsSuccess = false, Message = "Internal server error: EventID:" + EventID };
                return response;
            }


        }


    }




}