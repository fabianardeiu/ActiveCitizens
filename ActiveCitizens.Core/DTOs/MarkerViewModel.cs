using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Core.DTOs
{
    public class MarkerViewModel
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public bool Solved { get; set; }
        public byte[] Image { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByCitizen { get; set; }
        public string ResolvedByCitizen { get; set; }
    }
}
