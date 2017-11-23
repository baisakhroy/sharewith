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

    public class UserFileDetailsController : Controller
    {
    private readonly Sharewithcontext _context;

        public UserFileDetailsController(Sharewithcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<UserFileDetails>> GetAllUserDetails()
            {
                // return _service.GetAllUserDetails();
                return await _context.UserFileDetails.ToListAsync();
            }

        [HttpGet("{User_userID}")]
            public async Task<UserFileDetails> GetbyUser_userID (int User_userID, [FromBody] UserDetails item)
            {
                UserFileDetails todo =await _context.UserFileDetails.FirstOrDefaultAsync(t => t.UserID == User_userID);
                 return todo;
            }
    }
}