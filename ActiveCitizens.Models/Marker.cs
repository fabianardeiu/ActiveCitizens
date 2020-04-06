using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Models
{
    public class Marker
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public bool Solved { get; set; }
        public byte[] Image { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
