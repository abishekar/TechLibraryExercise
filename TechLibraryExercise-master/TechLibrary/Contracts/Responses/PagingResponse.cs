using System.Collections.Generic;
using TechLibrary.Contracts.BaseLibrary;

/// <summary>
/// Class for paging result DTO
/// </summary>
namespace TechLibrary.Contracts.Responses
{
    public class PagingResponse<T> : PagingResultBase where T : class
    {
        public List<T> Results { get; set; }

        public PagingResponse()
        {
            Results = new List<T>();
        }
    }
}