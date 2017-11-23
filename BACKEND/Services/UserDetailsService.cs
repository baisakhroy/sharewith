using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACKEND.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BACKEND.services
{
    public class UserDetailsService
    {
        private readonly Sharewithcontext _context;

        public UserDetailsService(Sharewithcontext context)
        {
            _context = context;
        } 

        [HttpGet]
        public async Task<List<UserDetails>> GetAllUserDetails()
            {
                return await _context.UserDetails.ToListAsync();
            }
    }
}