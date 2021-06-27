using System.Threading.Tasks;
using ECommerce.Domain.Repositories;
using ECommerce.Persistence.Context;

namespace ECommerce.Persistence.Repositories
{
    public class UnityOfWork: IUnityOfWork
    {
        private readonly DataAppContext _context;

        public UnityOfWork(DataAppContext context)
        {
            _context = context;
        }
        
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}