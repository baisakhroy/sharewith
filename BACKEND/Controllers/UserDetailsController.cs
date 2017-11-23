using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
// using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BACKEND.services;

namespace BACKEND.Controllers
{
    [Route("api/[controller]")]
    public class UserDetailsController: Controller
    {
        private readonly Sharewithcontext _context;
        // private readonly UserDetailsService _service;

        public UserDetailsController(Sharewithcontext context /*UserDetailsService service*/)
        {
            _context = context;
            // _service = service;
            // if (_context.mytable.Count() == 0)
            // {
            //     _context.mytable.Add(new mytable {  CreatedBy= "Baisakh" });
            //     _context.SaveChanges();
            // }

        } 
 
        [HttpGet]
       [Route("GetClientList/term")]  
       public  Microsoft.AspNetCore.Mvc.OkObjectResult GetUserbysearchedletters(string term)  
        {  
            var clientList = from c in _context.UserDetails  
                             where c.FirstName.Contains(term)  
                             select c;  
             return  Ok(clientList); 
         }  
            

        [HttpGet]
        public async Task<List<UserDetails>> GetAllUserDetails()
            {
                // return _service.GetAllUserDetails();
                return await _context.UserDetails.ToListAsync();
            }
        // [HttpGet]
        // public async Task<List<mytable>> GetAllmytable()
        //     {
        //         return await _context.mytable.ToListAsync();
        //     }
          

            [HttpGet("{firstname}")]
            public async Task<UserDetails> GetbyFirstname (string firstname, [FromBody] UserDetails item)
            {
                 UserDetails todo =await _context.UserDetails.FirstOrDefaultAsync(t => t.FirstName==firstname);
                 return todo;
            }

            [HttpPost]
            public async Task Post([FromBody] UserDetails item)
            {
                // if (item == null)
                // {
                //     return BadRequest();
                // }

                _context.UserDetails.Add(item);
                await _context.SaveChangesAsync();
                

                // return CreatedAtRoute("GetTodo", new { id = item.ProductId }, item);
            }
    }
}