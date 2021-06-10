using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Lease
    {
        public int LeaseId { get; set; }

        public int CustomerId { get; set; }

        public int MovieId { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsActive { get; set; }
    }
}
