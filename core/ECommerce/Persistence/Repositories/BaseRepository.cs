using ECommerce.Persistence.Context;

namespace ECommerce.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        private readonly DataAppContext _context;
        
        protected BaseRepository(DataAppContext context)
        {
            _context = context;
        }
        
    }
}