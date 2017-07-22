using AutoMapper;

namespace Catalog.Common.Utilities
{
    /// <summary>
    /// Uses AutoMammer nuget package to map EF <=> DTOs
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public class AutoMapperGenericsHelper<TSource, TDestination>
    {
        public static TDestination Convert(TSource source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TSource, TDestination>());
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}
