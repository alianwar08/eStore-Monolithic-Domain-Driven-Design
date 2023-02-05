using eStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Domain.Services
{
    public interface ICustomerServices
    {

        public bool IsCustomerAlreadyExisit(string email);

        public bool PersistCustomer(CustomerDE customer);


    }
}
