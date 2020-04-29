using System;
using System.Collections.Generic;
using System.Linq;
using ActiveCitizens.Core;
using ActiveCitizens.Core.Dto;
using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Core.Interfaces;
using ActiveCitizens.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActiveCitizens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkerController : Controller
    {
        private IMarkerRepository _markerRepo;
        private readonly ActiveCitizensContext _context = null;

        public MarkerController(IMarkerRepository markerRepo, ActiveCitizensContext context)
        {
            _markerRepo = markerRepo;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MarkerViewModel>> GetMarkers()
        {
            var markers = _markerRepo.GetAll();

            return Ok(markers);
        }

        [HttpGet("{id}")]
        public IActionResult GetMarkerById(Guid id)
        {
            var marker = _markerRepo.GetById(id);
            return Ok(marker);
        }

        [HttpPost]
        public ActionResult<MarkerViewModel> CreateMarker([FromBody] MarkerDto markerDto)
        {
            if (ModelState.IsValid)
            {
                var markerViewModel = _markerRepo.Add(markerDto);
                
                return Ok(markerViewModel);
            }
            else
            {
                return BadRequest("ModelState is not valid");
            }
        }
     
        [HttpDelete("{id}")]
        public IActionResult DeleteMarker(Guid id)
        {
            _markerRepo.DeleteById(id);
            return Ok("Marker deleted");
        }

        [HttpPut("solve")]
        public ActionResult<MarkerViewModel> SolveMarker([FromBody] SolveMarkerDto solveMarkerDto)
        {
            var solvedMarker = _markerRepo.Solve(solveMarkerDto.MarkerId, solveMarkerDto.Citizen);
            return Ok(solvedMarker);
        }
    }
}