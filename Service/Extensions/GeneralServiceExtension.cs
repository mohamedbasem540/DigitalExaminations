
using Contracts.Extensions;
using Entities.DBModels.SharedModels;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace CoreServices.Extensions
{
    public static class GeneralServiceSearchExtension
    {
        public static IQueryable<T> Search<T>(this IQueryable<T> data, string searchColumns, string searchTerm) where T : BaseEntity
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<T, bool>> expression = SearchQueryBuilder.CreateSearchQuery<T>(searchColumns, searchTerm);

            return data.Where(expression);
        }

    }

    public static class GeneralServiceSortExtension
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> data, string orderByQueryString) where T : BaseEntity
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<T>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }

    }
}
