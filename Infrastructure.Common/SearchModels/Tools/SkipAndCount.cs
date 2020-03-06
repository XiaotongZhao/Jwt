using System.Linq;

namespace Infrastructure.Common.SearchModels.Tools
{
    public static class SkipAndCount
    {
        public static DataSource takePageDataAndCount<TSource>(this IQueryable<TSource> source, int skip, int size)
        {
            DataSource result = new DataSource();
            result.Data = source.Skip((skip - 1) * size).Take(size);
            result.Count = source.Count();
            return result; ;
        }
    }
}
