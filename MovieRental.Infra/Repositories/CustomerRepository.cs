using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        public IEnumerable<Customer> ListCustomers()
        {
            return _dbContext.Set<Customer>().ToList();
        }

        public void CreateCustomer(Customer model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer model)
        {
            _dbContext.Entry(model).CurrentValues.SetValues(model);
            _dbContext.SaveChanges();
        }

        public Customer GetCustomer(int customerId)
        {
            return _dbContext.Set<Customer>().Where(x => x.CustomerId == customerId).FirstOrDefault();
        }
    }
}
