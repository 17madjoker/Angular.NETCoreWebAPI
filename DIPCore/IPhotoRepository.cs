using System.Collections.Generic;
using System.Threading.Tasks;
using AngularCoreApp.Models;

namespace AngularCoreApp.DIPCore
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int vehicleId);
    }
}