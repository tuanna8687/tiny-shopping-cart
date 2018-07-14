using System;
using AutoMapper;
using TinyShoppingCart.Presentation.Admin.MappingProfiles;

namespace TinyShoppingCart.Presentation.Admin.MappingProfiles
{
    public class QueryObjectMappingProfileFixture : IDisposable
    {
        public IMapper Mapper { get; private set; }

        public QueryObjectMappingProfileFixture()
        {
            var mapperConfiguration = new MapperConfiguration(e => e.AddProfile<QueryObjectMappingProfile>());
            Mapper = mapperConfiguration.CreateMapper();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Mapper = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~QueryObjectMappingProfileFixture() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}