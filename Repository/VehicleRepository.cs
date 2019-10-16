using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AngularCoreApp.DIPCore;
using AngularCoreApp.Extensions;
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

        public async Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery queryByClient)
        {
            var result = new QueryResult<Vehicle>();
            
            var query = _db.Vehicles
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .AsQueryable();

            if (queryByClient.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == queryByClient.MakeId.Value);
            
            if (queryByClient.ModelId.HasValue)
                query = query.Where(v => v.ModelId == queryByClient.ModelId.Value);

            var sortMap = new Dictionary<string, Expression<Func<Vehicle, object>>>();
            sortMap.Add("make", v => v.Model.Make.Name);
            sortMap.Add("model", v => v.Model.Name);

            query = query.Ordering(queryByClient, sortMap);

            result.TotalItems = await query.CountAsync();
            query = query.Paging(queryByClient);

            result.Items = await query.ToListAsync();

            return result;
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