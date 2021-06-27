using System.Collections.Generic;
using System.Threading.Tasks;
using BookstoreCollection.Domain.Models;

namespace BookstoreCollection.Domain.Repository
{
    public interface IBookstoreRepository
    {

        IEnumerable<Book> GetAll();

    }
}