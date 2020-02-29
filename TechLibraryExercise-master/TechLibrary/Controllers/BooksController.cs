using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechLibrary.Contracts.Responses;
using TechLibrary.Domain;
using TechLibrary.Helpers;
using TechLibrary.Models;
using TechLibrary.Services;

namespace TechLibrary.Controllers
{
    /// <summary>
    /// Books Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for Books controller
        /// </summary>
        /// <param name="logger">ILogger</param>
        /// <param name="bookService">BooksService</param>
        /// <param name="mapper">Automapper</param>
        public BooksController(ILogger<BooksController> logger, IBookService bookService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Books
        /// </summary>
        /// <returns>Collection of BookResponse</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Get all books");

                var books = await _bookService.GetBooksAsync();

                var bookResponse = _mapper.Map<List<BookResponse>>(books);

                return Ok(bookResponse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return Ok(ex.Message);
            }
        }

        /// <summary>
        /// Get All Books by paging
        /// </summary>
        /// <param name="parameters">BookSearch parameters which include title, description, current page & page number</param>
        /// <returns>Collection of BookResponse</returns>
        [HttpPost]
        [Route("BookSearch")]
        public async Task<IActionResult> GetAllbyPaging(BookSearchParams parameters)
        {
            try
            {
                _logger.LogInformation("Get all books by paging");

                var books = await _bookService.GetBooksAsync(parameters);

                var booksPagingResponse = _mapper.Map<PagingResponse<Book>>(books);

                return Ok(booksPagingResponse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return Ok(ex.Message);
            }
        }

        /// <summary>
        /// Book Upsert Inserts or Updates the Book based on BookID parameter
        /// </summary>
        /// <param name="bookobj">BookUpdateParams object includes the book object and any other related props</param>
        /// <returns>BookResponse</returns>
        [HttpPost]
        [Route("BookUpsert")]
        public async Task<IActionResult> SaveBook(BookUpdateParams bookobj)
        {
            try
            {
                _logger.LogInformation("Update Book short description for book ID: " + bookobj.book.BookId);

                var book = await _bookService.Upsert(bookobj.book);

                var bookResponse = _mapper.Map<BookResponse>(book);

                return Ok(bookResponse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return Ok(ex.Message);
            }
        }


        /// <summary>
        /// Get Book by ID
        /// </summary>
        /// <param name="id">BookID</param>
        /// <returns>BookResponse</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Get book by id {id}");

                var book = await _bookService.GetBookByIdAsync(id);

                var bookResponse = _mapper.Map<BookResponse>(book);

                return Ok(bookResponse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return Ok(ex.Message);
            }
        }
    }
}