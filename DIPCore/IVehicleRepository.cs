using System.Collections.Generic;
using System.Threading.Tasks;
using AngularCoreApp.Models;

namespace AngularCoreApp.DIPCore
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated);

        Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery filter);

        void Add(Vehicle vehicle);

        void Remove(Vehicle vehicle);
    }
}