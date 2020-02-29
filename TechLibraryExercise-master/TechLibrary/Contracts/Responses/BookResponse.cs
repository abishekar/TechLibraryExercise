using System.ComponentModel.DataAnnotations;

namespace TechLibrary.Models
{
    /// <summary>
    /// Book Entity DTO
    /// </summary>
    /// 
    public class BookResponse
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string PublishedDate { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ShortDescr { get; set; }
        public string LongDescr { get; set; }
        public TimestampAttribute RowVersion { get; set; }
     }
}