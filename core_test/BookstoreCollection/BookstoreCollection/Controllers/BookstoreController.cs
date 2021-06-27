using BookstoreCollection.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreCollection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookstoreController: ControllerBase
    {
        private readonly IBookstoreRepository _bookstoreRepository;

        public BookstoreController(IBookstoreRepository bookstoreRepository)
        {
            _bookstoreRepository = bookstoreRepository;
        }

        [HttpGet]
        public IActionResult GetAllCollection() => Ok(_bookstoreRepository.GetAll());
        

    }
}