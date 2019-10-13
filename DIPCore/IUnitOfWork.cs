using System.Threading.Tasks;

namespace AngularCoreApp.DIPCore
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}