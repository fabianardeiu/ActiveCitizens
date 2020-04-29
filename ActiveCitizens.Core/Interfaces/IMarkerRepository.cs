using ActiveCitizens.Core.Dto;
using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Core.Interfaces
{
    public interface IMarkerRepository
    {
        MarkerViewModel Add(MarkerDto markerDto);
        IEnumerable<MarkerViewModel> GetAll();
        Marker GetById(int id);
        void DeleteById(int id);
        MarkerViewModel Solve(int markerId);

    }
}
