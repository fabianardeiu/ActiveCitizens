using System;
using System.Collections.Generic;
using System.Linq;
using ActiveCitizens.Core;
using ActiveCitizens.Core.Dto;
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
        public IActionResult GetMarkers()
        {
            var markers = _markerRepo.GetAll();
            List<MarkerDto> markersDto = new List<MarkerDto>();
            markers.ToList().ForEach(m => markersDto.Add(
                new MarkerDto
                {
                    Id = m.Id,
                    Description = m.Description,
                    ImageBytes = m.Image,
                    Latitude = m.Latitude,
                    Longitude = m.Longitude,
                    Solved = m.Solved,
                    Citizen = m.Citizen.Name
                }
            ));

            return Ok(markersDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetMarkerById(int id)
        {
            var marker = _markerRepo.GetById(id);
            return Ok(marker);
        }

        [HttpPost]
        public IActionResult CreateMarker([FromBody] MarkerDto markerDto)
        {
            if (ModelState.IsValid)
            {
                Marker marker = new Marker
                {
                    Id = markerDto.Id,
                    Description = markerDto.Description,
                    Latitude = markerDto.Latitude,
                    Longitude = markerDto.Longitude,
                    Solved = markerDto.Solved,
                    CitizenId = _context.Citizens.SingleOrDefault(c => c.Name == markerDto.Citizen).Id
                };
                if (markerDto.Image != null)
                {
                    marker.Image = Convert.FromBase64String(markerDto.Image);
                }

                var createdMarker = _markerRepo.Add(marker);

                MarkerDto response = new MarkerDto
                {
                    Id = createdMarker.Id,
                    Description = createdMarker.Description,
                    Latitude = createdMarker.Latitude,
                    Longitude = createdMarker.Longitude,
                    Solved = createdMarker.Solved,
                    Citizen = createdMarker.Citizen.Name,
                    ImageBytes = createdMarker.Image
                };
                return Ok(response);
            }
            else
            {
                return BadRequest("ModelState is not valid");
            }
        }
     
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteMarker(int id)
        {
            _markerRepo.DeleteById(id);
            return Ok("Marker deleted");
        }

        [HttpGet("{markerId}/solve")]
        public IActionResult SolveMarker(int markerId)
        {
            var solvedMarker = _markerRepo.Solve(markerId);
            return Ok(solvedMarker);
        }
    }
}