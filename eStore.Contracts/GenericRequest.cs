using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENUMS;

namespace eStore.Contracts
{
    public record GenericRequest
    {
        public GenericRequest()
        { 

        }

        /// <summary>
        /// TODO:
        /// </summary>
        public string AuthenticationToken;
    }

    public record GenericResponse
    {
        public GenericResponse()
        {

        }


        /// <summary>
        /// TODO:
        /// </summary>
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }


}
