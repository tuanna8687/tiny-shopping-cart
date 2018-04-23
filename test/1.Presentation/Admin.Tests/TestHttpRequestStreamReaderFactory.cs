using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.WebUtilities;

namespace TinyShoppingCart.Server.Presentation.Admin
{
    public class TestHttpRequestStreamReaderFactory : IHttpRequestStreamReaderFactory
    {
        public TextReader CreateReader(Stream stream, Encoding encoding)
        {
            return new HttpRequestStreamReader(stream, encoding);
        }
    }
}