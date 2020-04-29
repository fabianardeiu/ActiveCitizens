using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Core.Interfaces
{
    public interface IAuthentificationService
    {
        CitizenDto Login(User user);
    }
}
