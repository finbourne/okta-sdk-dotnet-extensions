using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Utils
{
    /// <summary>
    /// Extension methods related to using collections in the Okta SDK
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Pull all items in the collection into an in-memory list
        /// </summary>
        public static async Task<IList<T>> ToListAsync<T>(this ICollectionClient<T> collectionClient, CancellationToken cancellationToken)
            where T : IResource
        {   
            var pages = collectionClient.GetPagedEnumerator();
            var items = new List<T>();
                
            while (await pages.MoveNextAsync(cancellationToken))
            {
                items.AddRange(pages.CurrentPage.Items);
            }

            return items;
        }

        /// <summary>
        /// Cast a collection to a specific type and return it as a list
        /// </summary>
        public static IList<TOutput> CastToList<TInput, TOutput>(this IEnumerable<TInput> input)
        {
            return input.Cast<TOutput>().ToList();
        }
    }
}