using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechLibrary.Contracts.Responses;

/// <summary>
/// 
/// </summary>
namespace TechLibrary.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class PagingQuery
    {
        /// <summary>
        /// Extension method to imlement Server side paging for IQueryable generic type. 
        /// </summary>
        /// <typeparam name="T">IQueryable Entity</typeparam>
        /// <param name="query"></param>
        /// <param name="page">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>Returns a Custom Paging reponse type which includes the List of 
        /// Specific Entity along with paging information</returns>
        public static PagingResponse<T> GetPaged<T>(this IQueryable<T> query,
        int page, int pageSize) where T : class
        {
            var result = new PagingResponse<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        /// <summary>
        /// Asynchronos Extension method to imlement Server side paging for IQueryable generic type. 
        /// </summary>
        /// <typeparam name="T">IQueryable Entity</typeparam>
        /// <param name="query"></param>
        /// <param name="page">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>Returns a Custom Paging reponse type which includes the List of 
        /// Specific Entity along with paging information</returns>
        public static async Task<PagingResponse<T>> GetPagedAsync<T>(this IQueryable<T> query,
        int page, int pageSize) where T : class
        {
            var result = new PagingResponse<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}