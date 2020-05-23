using ActiveCitizens.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Core.Interfaces
{
    public interface ICitizenRepository
    {
        IEnumerable<LeaderboardDto> GetLeaderboard();
    }
}
