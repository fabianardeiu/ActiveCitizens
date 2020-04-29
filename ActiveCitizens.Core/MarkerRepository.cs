using ActiveCitizens.Core.Dto;
using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Core.Interfaces;
using ActiveCitizens.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveCitizens.Core
{
    public class MarkerRepository : IMarkerRepository
    {
        private readonly ActiveCitizensContext _context = null;

        public MarkerRepository(ActiveCitizensContext context)
        {
            _context = context;
        }

        public MarkerViewModel Add(MarkerDto markerDto)
        {
            Marker marker = new Marker
            {
                Id = markerDto.Id,
                Description = markerDto.Description,
                Image = markerDto.Image != null ? Convert.FromBase64String(markerDto.Image) : null,
                Latitude = markerDto.Latitude,
                Longitude = markerDto.Longitude,
                CreatedAt = DateTime.Now,
                Solved = markerDto.Solved,
                CreatedByCitizenId = _context.Citizens.SingleOrDefault(c => c.Name == markerDto.CreatedByCitizen).Id
            };

            _context.Markers.Add(marker);
            _context.SaveChanges();

            MarkerViewModel markerViewModel = new MarkerViewModel
            {
                Id = marker.Id,
                Description = marker.Description,
                Latitude = marker.Latitude,
                Longitude = marker.Longitude,
                Solved = marker.Solved,
                CreatedByCitizen = marker.CreatedByCitizen.Name,
                Image = marker.Image
            };

            return markerViewModel;
        }

        public void DeleteById(Guid id)
        {
            var marker = _context.Markers.FirstOrDefault(m => m.Id == id);
            if (marker != null)
            {
                _context.Markers.Remove(marker);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MarkerViewModel> GetAll()
        {
            var markers = _context.Markers
                .Include(m => m.CreatedByCitizen)
                .Include(m => m.ResolvedByCitizen)
                .Where(m => m.ResolvedAt == null || m.ResolvedAt > DateTime.Now.AddDays(-7));

            List<MarkerViewModel> markersDto = new List<MarkerViewModel>();
            markers.ToList().ForEach(m => markersDto.Add(
                new MarkerViewModel
                {
                    Id = m.Id,
                    Description = m.Description,
                    Image = m.Image,
                    Latitude = m.Latitude,
                    Longitude = m.Longitude,
                    Solved = m.Solved,
                    CreatedAt = m.CreatedAt,
                    ResolvedAt = m.ResolvedAt != null ? m.ResolvedAt : null,
                    CreatedByCitizen = m.CreatedByCitizen.Name,
                    ResolvedByCitizen = m.ResolvedByCitizen != null ? m.ResolvedByCitizen.Name : null
                }
            ));

            return markersDto;
        }

        public Marker GetById(Guid id)
        {
            var marker = _context.Markers.FirstOrDefault(m => m.Id == id);
            return marker;
        }

        public MarkerViewModel Solve(Guid markerId, string citizen)
        {
            var marker = _context.Markers.FirstOrDefault(m => m.Id == markerId);
            marker.Solved = true;
            marker.ResolvedAt = DateTime.Now;
            marker.ResolvedByCitizen = _context.Citizens.SingleOrDefault(c => c.Name == citizen);
            _context.SaveChanges();

            var solvedMarker = _context.Markers
                                       .Include(m => m.CreatedByCitizen)
                                       .SingleOrDefault(m => m.Id == markerId);

            var markerViewModel = new MarkerViewModel
            {
                Id = solvedMarker.Id,
                Description = solvedMarker.Description,
                Image = solvedMarker.Image,
                Latitude = solvedMarker.Latitude,
                Longitude = solvedMarker.Longitude,
                Solved = solvedMarker.Solved,
                ResolvedAt = solvedMarker.ResolvedAt,
                CreatedByCitizen = solvedMarker.CreatedByCitizen.Name,
                ResolvedByCitizen = solvedMarker.ResolvedByCitizen.Name
            };

            return markerViewModel;
        }
    }
}
