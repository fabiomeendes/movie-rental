using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class LeaseRepository : ILeaseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LeaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        public IEnumerable<Lease> ListLeases()
        {
            return _dbContext.Set<Lease>().ToList();
        }

        public void CreateLease(Lease model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public void UpdateLease(Lease model)
        {
            _dbContext.Entry(model).CurrentValues.SetValues(model);
            _dbContext.SaveChanges();
        }
    }
}
