using ActiveCitizens.Core.Dto;
using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Models;
using System;
using System.Collections.Generic;

namespace ActiveCitizens.Core.Interfaces
{
    public interface IMarkerRepository
    {
        MarkerViewModel Add(MarkerDto markerDto);
        IEnumerable<MarkerViewModel> GetAll();
        Marker GetById(Guid id);
        void DeleteById(Guid id);
        MarkerViewModel Solve(Guid markerId, string citizen);

    }
}
