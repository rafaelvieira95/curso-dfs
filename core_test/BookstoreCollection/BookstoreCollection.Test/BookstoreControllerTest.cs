using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreCollection.Controllers;
using BookstoreCollection.Domain.Models;
using BookstoreCollection.Domain.Repository;
using Xunit;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreCollection.Test
{
    public class BookstoreControllerTest
    {
        [Fact]
        public void GetAllBooksCollectionTest()
        {
            //Arrange
            var count = 5;
            var fakeBooks = A.CollectionOfDummy<Book>(count).AsEnumerable();
            var dataStore = A.Fake<IBookstoreRepository>();
            A.CallTo(() => dataStore.GetAll()).Returns(fakeBooks);
            var controller = new BookstoreController(dataStore);

            //Act
            var actionResult = controller.GetAllCollection();
            
            //Assert
            var result = actionResult as OkObjectResult;
            var returnBooks = result.Value as IEnumerable<Book>;
            Assert.Equal(count, returnBooks.Count());

        }
    }
}