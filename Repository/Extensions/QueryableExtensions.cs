using System;
using System.Linq;

namespace Repository.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> DistinctBy<T, TProperty>(this IQueryable<T> query, Func<T, TProperty> propertySelector) where T: class
        {
            var x = query.GroupBy(propertySelector).Select(x => x.FirstOrDefault()) as IQueryable<T>;

            return x;
        }
    }
}
