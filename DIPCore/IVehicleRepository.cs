using System.Threading.Tasks;
using AngularCoreApp.Models;

namespace AngularCoreApp.DIPCore
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated);

        void Add(Vehicle vehicle);

        void Remove(Vehicle vehicle);
    }
}