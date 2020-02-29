using AutoMapper;
using TechLibrary.Domain;
using TechLibrary.Models;

namespace TechLibrary.MappingProfiles
{
    /// <summary>
    /// 
    /// </summary>
    public class DomainToResponseProfile : Profile
    {
        /// <summary>
        /// Automapper Mappings
        /// </summary>
        public DomainToResponseProfile()
        {
            CreateMap<Book, BookResponse>().ForMember(x => x.ShortDescr, opt => opt.MapFrom(src => src.ShortDescr));
            CreateMap<Book, BookResponse>().ForMember(x => x.LongDescr, opt => opt.MapFrom(src => src.LongDescr));
        }
    }
}