using ActiveCitizens.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Core.Interfaces
{
    public interface IMarkerRepository
    {
        Marker Add(Marker marker);
        IEnumerable<Marker> GetAll();
        Marker GetById(int id);
        void DeleteById(int id);

    }
}
