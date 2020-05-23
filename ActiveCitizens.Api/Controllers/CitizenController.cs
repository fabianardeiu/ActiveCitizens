

using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ActiveCitizens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : Controller
    {
        private ICitizenRepository _citizenRepo;

        public CitizenController(ICitizenRepository citizenRepo)
        {
            _citizenRepo = citizenRepo;
        }

        [HttpGet("leaderboard")]
        public ActionResult<IEnumerable<LeaderboardDto>> GetLeaderboard()
        {
            var leaderboard = _citizenRepo.GetLeaderboard();

            return Ok(leaderboard);
        }

    }
}
