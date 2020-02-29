using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechLibrary.Contracts.Responses;
using TechLibrary.Helpers;
using TechLibrary.Services;

namespace TechLibrary.Controllers.Tests
{
    [TestFixture()]
    [Category("ControllerTests")]
    public class BooksControllerTests
    {
        private Mock<ILogger<BooksController>> _mockLogger;
        private Mock<IBookService> _mockBookService;
        private Mock<IMapper> _mockMapper;
        private NullReferenceException _expectedException;
        private Mock<BookSearchParams> _mockBookParams;

        private static BookSearchParams[] PagingParamCases =
        {
         new BookSearchParams() {title="Android", description="this",pageNumber=1,pageSize= 10 },
         new BookSearchParams() {title="Flex", description=" ",pageNumber=1,pageSize= 20 }
        };

        private static BookUpdateParams[] UpdateParamcases =
            {
            new BookUpdateParams() { book= new Domain.Book ()
            {
                BookId=0,
                Title="New Title 1",
                ThumbnailUrl="https://s3.amazonaws.com/AKIAJC5RLADLUMVRPFDQ.book-thumb-images/black.jpg",
                ISBN="9999999XX5",
                PublishedDate="28-Feb-2020",
                ShortDescr="Short Desc",
                LongDescr="Long Desc"
                } },
            new BookUpdateParams() { book= new Domain.Book ()
            {
                BookId=9,
                Title="New Title 2",
                ThumbnailUrl="https://s3.amazonaws.com/AKIAJC5RLADLUMVRPFDQ.book-thumb-images/black.jpg",
                ISBN="9999999XX6",
                PublishedDate="29-Feb-2020",
                ShortDescr="Short Desc 1",
                LongDescr="Long Desc 2"
                } }
        };

        [OneTimeSetUp]
        public void TestSetup()
        {
            _expectedException = new NullReferenceException("Test Failed...");
            _mockLogger = new Mock<ILogger<BooksController>>();
            _mockBookService = new Mock<IBookService>();
            _mockMapper = new Mock<IMapper>();
            _mockBookParams = new Mock<BookSearchParams>();
        }

        [Test()]
        public async Task GetAllTest()
        {
            //  Arrange
            _mockBookService.Setup(b => b.GetBooksAsync()).Returns(Task.FromResult(It.IsAny<List<Domain.Book>>()));
            var sut = new BooksController(_mockLogger.Object, _mockBookService.Object, _mockMapper.Object);

            //  Act
            var result = await sut.GetAll();

            //  Assert
            _mockBookService.Verify(s => s.GetBooksAsync(), Times.Once, "Expected GetBooksAsync to have been called once");
        }

        [Test()]
        [TestCaseSource("PagingParamCases")]
        public async Task GetAllbyPaging(BookSearchParams parameters)
        {
            // Arrange
            _mockBookService.Setup(b => b.GetBooksAsync(parameters)).Returns(Task.FromResult(It.IsAny<PagingResponse<Domain.Book>>()));
            var sut = new BooksController(_mockLogger.Object, _mockBookService.Object, _mockMapper.Object);

            //Act
            var result = await sut.GetAllbyPaging(parameters);

            //Assert
            _mockBookService.Verify(s => s.GetBooksAsync(parameters), Times.Once, "Expected GetBooksAsync Overload(parameters) to have called once");
        }

        [Test()]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(7)]
        [TestCase(8)]
        public async Task GetById(int id)
        {
            //  Arrange
            _mockBookService.Setup(b => b.GetBookByIdAsync(id)).Returns(Task.FromResult(It.IsAny<Domain.Book>()));
            var sut = new BooksController(_mockLogger.Object, _mockBookService.Object, _mockMapper.Object);

            //  Act
            var result = await sut.GetById(id);

            //  Assert
            _mockBookService.Verify(s => s.GetBookByIdAsync(id), Times.Once, "Expected GetBookByIdAsync to have been called once");
        }

        [Test()]
        [TestCaseSource("UpdateParamcases")]
        public async Task SaveBook(BookUpdateParams bookobj)
        {
            //  Arrange
            _mockBookService.Setup(b => b.Upsert(bookobj.book)).Returns(Task.FromResult(It.IsAny<Domain.Book>()));
            var sut = new BooksController(_mockLogger.Object, _mockBookService.Object, _mockMapper.Object);

            //  Act
            var result = await sut.SaveBook(bookobj);

            //  Assert
            _mockBookService.Verify(s => s.Upsert(bookobj.book), Times.Once, "Expected SaveBook to have been called once");
        }
    }
}