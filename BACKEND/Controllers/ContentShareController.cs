using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BACKEND.services;
using System;

namespace BACKEND.Controllers
{
    [Route("api/[controller]")]
    public class ContentShareController : Controller
    {
        private readonly Sharewithcontext _context;

        public ContentShareController (Sharewithcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<ContentShare>> GetAllContentShare(){
            return await _context.ContentShare.ToListAsync();
        }
        [HttpPost]
        public async Task Post([FromBody] ContentShare item)
            {
                try
                {
                    item.CreatedOn=System.DateTime.Now;
                    item.ModifiedOn=System.DateTime.Now;
                _context.ContentShare.Add(item);
                await _context.SaveChangesAsync();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
    }
}