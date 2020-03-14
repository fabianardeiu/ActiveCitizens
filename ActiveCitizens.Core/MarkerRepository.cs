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
            return _context.Markers;
        }

        public Marker GetById(int id)
        {
            var marker = _context.Markers.FirstOrDefault(m => m.Id == id);
            return marker;
        }

        public void Update(Marker marker)
        {
            _context.Attach(marker);
            var entry = _context.Entry(marker);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
