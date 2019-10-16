using System.Collections.Generic;
using System.Threading.Tasks;
using AngularCoreApp.Mapping.Resources;
using AngularCoreApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularCoreApp.Controllers
{
    public class ModelsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ModelsController(AppDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        
        [HttpGet("/api/models")]
        public async Task<IEnumerable<KeyValuePairResource>> GetModels()
        {
            var models = await _db.Models.ToListAsync();
            
            return _mapper.Map<List<Model>, List<KeyValuePairResource>>(models);
        }
    }
}