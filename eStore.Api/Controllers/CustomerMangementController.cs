using Azure.Core;
using eStore.Application;
using eStore.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerMangementController : ControllerBase
    {
        private readonly ILogger<CustomerMangementController> _logger;

        public CustomerMangementController(ILogger<CustomerMangementController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost("AddCustomer")]
        public AddCustomerResponse AddCustomer(AddCustomerRequest request)
        {
            AddCustomerResponse response;
            try
            {
                var IM = new CustomerMangementAS();
                response = IM.AddCustomer(request);
                return response;
            }

            catch(Exception ex)
            {
                var EventID = Math.Abs (Guid.NewGuid().GetHashCode());
                _logger.LogError(new EventId(EventID), ex, "App server return with exception", request);
                response = new AddCustomerResponse() { IsSuccess = false, Message = "Internal server error: EventID:"+ EventID };
                return response;
            }
            

        }


        [HttpPost("GetCustomer")]
        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            GetCustomerResponse response;
            try
            {
                var IM = new CustomerMangementAS();
                response = IM.GetCustomer(request);
                return response;
            }

            catch (Exception ex)
            {
                var EventID = Math.Abs(Guid.NewGuid().GetHashCode());
                _logger.LogError(new EventId(EventID), ex, "App server return with exception", request);
                response = new GetCustomerResponse() { IsSuccess = false, Message = "Internal server error: EventID:" + EventID };
                return response;
            }


        }

    }




}