using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using BookstoreCollection.Domain.Models;
using BookstoreCollection.Domain.Repository;

namespace BookstoreCollection.Data.Repository
{
    public class BookStoreRepository: IBookstoreRepository
    {
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>()
            {
                new Book {
                    Id = 1, 
                    Title = "Memórias póstumas  de Brás Cubas", 
                    NameAuthor = "Machado de Assis", 
                    SerialNumber = "12397273788263",
                    Year="1881"},
                new Book{
                    Id = 2,
                    Title = "Sertões", 
                    NameAuthor = "Euclides da Cunha", 
                    SerialNumber = "8871828273213",
                    Year = "1902"},
                new Book {
                    Id = 3,
                    Title = "Triste fim de Policarpo Quaresma", 
                    NameAuthor = "Lima Barreto", 
                    SerialNumber = "887182827343242",
                    Year = "1950"
                },
                new Book {
                    Id = 4,
                    Title = "Capitães de Areia", 
                    NameAuthor = "Jorge Amado", 
                    SerialNumber = "88718282110291",
                    Year = "1937"
                },
                new Book {
                    Id = 5,
                    Title = "Vidas Secas", 
                    NameAuthor = "Graciliano Ramos", 
                    SerialNumber = "126377328273898",
                    Year = "1930"
                }
            };
        }
    }
}