using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
