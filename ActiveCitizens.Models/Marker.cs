using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ActiveCitizens.Models
{
    public class Marker
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public bool Solved { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }

        [Display(Name = "CreatedByCitizen")]
        public Guid CreatedByCitizenId { get; set; }

        [ForeignKey("CreatedByCitizenId")]
        [InverseProperty("CreatedMarkers")]
        public Citizen CreatedByCitizen { get; set; }

        [Display(Name = "ResolvedByCitizen")]
        public Guid? ResolvedByCitizenId { get; set; }

        [ForeignKey("ResolvedByCitizenId")]
        [InverseProperty("ResolvedMarkers")]
        public Citizen ResolvedByCitizen { get; set; }
    }
}
