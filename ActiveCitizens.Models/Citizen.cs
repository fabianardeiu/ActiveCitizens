using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ActiveCitizens.Models
{
    public class Citizen
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        [InverseProperty("CreatedByCitizen")]
        public ICollection<Marker> CreatedMarkers { get; set; }
        [InverseProperty("ResolvedByCitizen")]
        public ICollection<Marker> ResolvedMarkers { get; set; }
    }
}
