using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularCoreApp.DIPCore;
using AngularCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularCoreApp.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext _db;

        public PhotoRepository(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
        {
            return await _db.Photos
                .Where(p => p.VehicleId == vehicleId)
                .ToListAsync();
        }
    }
}