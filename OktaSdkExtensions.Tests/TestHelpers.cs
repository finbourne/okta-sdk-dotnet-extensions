using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Okta.Sdk;
using Okta.Sdk.Internal;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    /// <summary>
    /// Methods to assist in testing with Okta sdk constructs
    /// </summary>
    internal static class TestHelpers
    {
        internal static CollectionClient<T> CreateCollectionClient<T>(IEnumerable<T> testItems, int pageSize = 1000)
            where T: IResource
        {

            var mockDataStore = new Mock<IDataStore>(MockBehavior.Strict);
            mockDataStore.Setup(x =>
                    x.GetArrayAsync<T>(It.IsAny<HttpRequest>(), It.IsAny<RequestContext>(),
                        It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new HttpResponse<IEnumerable<T>>(){ Payload = testItems}));
            
            return new CollectionClient<T>(mockDataStore.Object, new HttpRequest(), new RequestContext());
        }
    }
}