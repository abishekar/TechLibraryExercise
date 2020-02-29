using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechLibrary.Contracts.Responses;
using TechLibrary.Data;
using TechLibrary.Domain;
using TechLibrary.Extensions;
using TechLibrary.Helpers;

namespace TechLibrary.Services
{
    /// <summary>
    /// Book Repository Contract
    /// </summary>
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();

        Task<PagingResponse<Book>> GetBooksAsync(BookSearchParams parameters);

        Task<Book> GetBookByIdAsync(int bookid);

        Task<Book> Upsert(Book book);
    }

    /// <summary>
    /// 
    /// </summary>
    public class BookService : IBookService
    {
        
        private readonly DataContext _dataContext;

        /// <summary>
        /// Constructor to set the dbContext
        /// </summary>
        /// <param name="dataContext">Inject DBContext</param>
        public BookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Get All Books 
        /// </summary>
        /// <returns>All Books</returns>
        public async Task<List<Book>> GetBooksAsync()
        {
            var queryable = _dataContext.Books.AsQueryable();
            return await queryable.ToListAsync();
        }

        /// <summary>
        /// Get All Books with search filters
        /// </summary>
        /// <param name="parameters">Object with filters title, description, page number & page size</param>
        /// <returns>Filtered Books</returns>
        public async Task<PagingResponse<Book>> GetBooksAsync(BookSearchParams parameters)
        {
            var result = await getFilteredBooks(_dataContext.Books.AsQueryable(), parameters).GetPagedAsync(parameters.pageNumber, parameters.pageSize);
            return result;
        }

        /// <summary>
        /// Helper method to apply the filter using where conditions
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters">title & description</param>
        /// <returns>query with filters</returns>
        private IQueryable<Book> getFilteredBooks(IQueryable<Book> query, BookSearchParams parameters)
        {
            if (!String.IsNullOrEmpty(parameters.title))
            {
                query = query.Where(b => b.Title.Contains(parameters.title));
            }
            if (!String.IsNullOrEmpty(parameters.description))
            {
                query = query.Where(b => b.ShortDescr.Contains(parameters.description));
            }
            return query;
        }

        /// <summary>
        /// Get Book by Id
        /// </summary>
        /// <param name="bookid">Book ID</param>
        /// <returns>Book</returns>
        public async Task<Book> GetBookByIdAsync(int bookid)
        {
            return await _dataContext.Books.SingleOrDefaultAsync(x => x.BookId == bookid);
        }

        /// <summary>
        /// Upserts Book, i.e if Book ID is 0 the Inserts book if ID not zero the Updates Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Book</returns>
        public async Task<Book> Upsert(Book book)
        {
            if (book.BookId == 0)
            {
                _dataContext.Entry(book).State = EntityState.Added;
                _dataContext.Books.Add(book);
            }
            else
            {
                _dataContext.Entry(book).State = EntityState.Modified;
                _dataContext.Books.Update(book);
            }

            await _dataContext.SaveChangesAsync();
            return book;
        }
    }
}