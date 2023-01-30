using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Core.Exceptions
{
    public class RecordNotFoundException : CustomeException
    {
        public RecordNotFoundException(string message) : base(message) {

           
        }
    }
}
