using TechLibrary.Domain;

/// <summary>
/// 
/// </summary>
namespace TechLibrary.Helpers
{
    /// <summary>
    /// Parameters for Book Search
    /// </summary>
    public class BookSearchParams
    {
        public string title { get; set; }
        public string description { get; set; }

        public int pageNumber { get; set; }

        public int pageSize { get; set; }
    }

    /// <summary>
    /// Parameters for Posting the Book Entity
    /// </summary>
    public class BookUpdateParams
    {
        public Book book { get; set; }
    }
}