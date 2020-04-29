﻿using ActiveCitizens.Core.DTOs;
using ActiveCitizens.Core.Interfaces;
using ActiveCitizens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveCitizens.Core
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly ActiveCitizensContext _context = null;

        public AuthentificationService(ActiveCitizensContext context)
        {
            _context = context;
        }

        public CitizenDto Login(User user)
        {
            var foundUser = _context.Users
                .SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (foundUser != null)
            {
                return new CitizenDto
                {
                    Name = _context.Citizens.SingleOrDefault(c => c.UserId == foundUser.Id).Name
                };
            }
            return null;
        }
    }
}
