using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Core.DTOs
{
    public class LeaderboardDto
    {
        //public int Rank { get; set; }
        public string Name { get; set; }
        public int Solved { get; set; }
        public int Created { get; set; }
        public int Score { get; set; }
    }
}
