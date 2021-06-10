using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> ListCustomers();

        Customer GetCustomer(int customerId);

        void CreateCustomer(Customer model);

        void DeleteCustomer(Customer model);
    }
}
