using System.Threading.Tasks;
using AngularCoreApp.DIPCore;
using AngularCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularCoreApp.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _db;

        public VehicleRepository(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated)
        {
            if (!includeRelated)
                return await _db.Vehicles.FindAsync(id);
            
            return await _db.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vehicle> GetVehicleWithMake(int id)
        {
            return await _db.Vehicles
                .Include(v => v.Model)
                .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            _db.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            _db.Vehicles.Remove(vehicle);
        }
    }
}