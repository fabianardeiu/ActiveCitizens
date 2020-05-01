using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCitizens.Core.Interfaces
{
    public interface IAuthentificationService
    {
        CitizenDto Login(User user);
        void Register(RegisterUserDto registerUserDto);
    }
}
