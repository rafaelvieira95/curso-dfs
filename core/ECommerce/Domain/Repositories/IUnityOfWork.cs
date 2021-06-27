using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface IUnityOfWork
    {
        Task CompleteAsync();
    }
}