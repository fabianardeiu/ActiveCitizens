using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Core.Dto
{
    public class MarkerDto
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public bool Solved { get; set; }
        public string Image { get; set; }
    }
}
