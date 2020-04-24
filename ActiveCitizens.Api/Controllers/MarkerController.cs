using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActiveCitizens.Core.Dto;
using ActiveCitizens.Core.Interfaces;
using ActiveCitizens.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActiveCitizens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkerController : Controller
    {
        private IMarkerRepository _markerRepo;

        public MarkerController(IMarkerRepository markerRepo)
        {
            _markerRepo = markerRepo;
        }

        [HttpGet]
        public IActionResult GetMarkers()
        {
            var markers = _markerRepo.GetAll();
            return Ok(markers);
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
                };
                if (markerDto.Image != null)
                {
                    marker.Image = Convert.FromBase64String(markerDto.Image);
                }

                var createdMarker = _markerRepo.Add(marker);
                return Ok(createdMarker);
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