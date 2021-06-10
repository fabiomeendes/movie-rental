using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ILeaseRepository
    {
        IEnumerable<Lease> ListLeases();

        void CreateLease(Lease model);

        void UpdateLease(Lease model);
    }
}
