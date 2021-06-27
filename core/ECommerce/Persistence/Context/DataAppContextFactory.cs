using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerce.Persistence.Context
{
    public class DataAppContextFactory: IDesignTimeDbContextFactory<DataAppContext>
    {
        public DataAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataAppContext>();

            optionsBuilder.UseNpgsql(@"Server=127.0.0.1; port=5432; user id=postgres; password=root; database=ecommerce;");
            return new DataAppContext(optionsBuilder.Options);
        }
    }
}