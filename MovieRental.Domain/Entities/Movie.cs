using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Name { get; set; }

        public int DaysMax { get; set; }

        public bool IsRent { get; set; }

        public bool IsActive { get; set; }
    }
}
