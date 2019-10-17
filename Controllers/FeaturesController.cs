using System.Collections.Generic;
using System.Threading.Tasks;
using AngularCoreApp.Mapping.Resources;
using AngularCoreApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularCoreApp.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public FeaturesController(AppDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        
        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var features = await _db.Features.ToListAsync();
            
            return _mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }
    }
}