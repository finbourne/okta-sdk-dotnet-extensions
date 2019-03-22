using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    internal class TestPagedEnumerator<T> : IPagedCollectionEnumerator<T>
        where T : IResource
    {
        private bool _isFirstRun = true;
        private int _pointer = 0;
        private readonly int _pageSize;
            
        private readonly T[] _thingsWeWantReturned;
            
        public CollectionPage<T> CurrentPage => new CollectionPage<T>(){Items = _thingsWeWantReturned.Skip(_pointer).Take(_pageSize) };

        public TestPagedEnumerator(IEnumerable<T> thingsWeWantReturned, int pageSize)
        {
            _thingsWeWantReturned = thingsWeWantReturned.ToArray();
            _pageSize = pageSize;
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!_isFirstRun)
            {
                _pointer += _pageSize;
            }
            _isFirstRun = false;
                
            return Task.FromResult(_pointer < _thingsWeWantReturned.Length);
        }
    }
}