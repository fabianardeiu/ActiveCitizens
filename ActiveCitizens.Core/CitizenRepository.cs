using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveCitizens.Core
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly ActiveCitizensContext _context = null;

        public CitizenRepository(ActiveCitizensContext context)
        {
            _context = context;
        }

        public IEnumerable<LeaderboardDto> GetLeaderboard()
        {
            int rank = 1;
            var leaderBoard = _context.Citizens
                                      .Include(c => c.ResolvedMarkers)
                                      .Include(c => c.CreatedMarkers)
                                      .Select(c => new LeaderboardDto
                                      {
                                          Name = c.Name,
                                          Solved = c.ResolvedMarkers.Count(),
                                          Created = c.CreatedMarkers.Count(),
                                          Score = c.ResolvedMarkers.Count() * 2 + c.CreatedMarkers.Count()
                                      })
                                      .OrderByDescending(c => c.Score);

            //leaderBoard.ToList().ForEach(c => {
            //    c.Rank = rank;
            //    rank++;
            //});

            return leaderBoard;
        }
    }
}
