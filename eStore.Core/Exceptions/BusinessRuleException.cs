using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Core.Exceptions
{
    public class BusinessRuleException : CustomeException
    {
        public BusinessRuleException(string message) : base(message) {

           
        }
    }
}
