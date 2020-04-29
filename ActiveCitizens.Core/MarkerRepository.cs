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

        public Marker Add(Marker marker)
        {
            marker.CreatedAt = DateTime.Now;
            _context.Markers.Add(marker);
            _context.SaveChanges();
            return marker;
        }

        public void DeleteById(int id)
        {
            var marker = _context.Markers.FirstOrDefault(m => m.Id == id);
            if(marker != null)
            {
                _context.Markers.Remove(marker);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Marker> GetAll()
        {
            return _context.Markers
                .Include(m => m.Citizen)
                .Where(m => m.ResolvedAt == null || m.ResolvedAt > DateTime.Now.AddDays(-7));
        }

        public Marker GetById(int id)
        {
            var marker = _context.Markers.FirstOrDefault(m => m.Id == id);
            return marker;
        }

        public Marker Solve(int markerId)
        {
            var marker = _context.Markers.FirstOrDefault(m => m.Id == markerId);
            marker.Solved = true;
            marker.ResolvedAt = DateTime.Now;
            _context.SaveChanges();
            return marker;
        }
    }
}
