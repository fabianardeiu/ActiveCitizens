using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActiveCitizens.Core.Interfaces;
using ActiveCitizens.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActiveCitizens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
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
        public IActionResult CreateMarker([FromBody] Marker marker)
        {
            if (ModelState.IsValid)
            {
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
    }
}