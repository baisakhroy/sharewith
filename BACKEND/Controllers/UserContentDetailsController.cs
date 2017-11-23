// 9446265490
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BACKEND.services;

namespace BACKEND.Controllers
{
    [Route("api/[controller]")]
    
        public class UserContentDetailsController : Controller
        {
            private readonly Sharewithcontext _context;
        
        public UserContentDetailsController (Sharewithcontext context /*UserDetailsService service*/)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<UserContentDetails>> GetAllUserContentDetails()
            {
                // return _service.GetAllUserDetails();
                return await _context.UserContentDetails.ToListAsync();
            }
            
        [HttpGet("{userID}")]
            public async Task<UserContentDetails> GetbyUserID (int UserID, [FromBody] UserContentDetails item)
            {
                UserContentDetails todo =await _context.UserContentDetails.FirstOrDefaultAsync(t => t.UserID == UserID);
                 return todo;
            }
    }
}