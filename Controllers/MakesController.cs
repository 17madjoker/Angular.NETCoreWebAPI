using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularCoreApp.Mapping.Resources;
using AngularCoreApp.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularCoreApp.Controllers
{
    public class MakesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public MakesController(AppDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await _db.Makes.Include(m => m.Models).ToListAsync();
            
            return _mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}