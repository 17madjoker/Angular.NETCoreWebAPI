using System.Threading.Tasks;
using AngularCoreApp.DIPCore;
using AngularCoreApp.Models;

namespace AngularCoreApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task CompleteAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}