using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Models
{
    public class Citizen
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Marker> Markers { get; set; }
    }
}
