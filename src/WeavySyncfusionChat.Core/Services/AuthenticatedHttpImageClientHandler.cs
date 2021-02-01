using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WeavySyncfusionChat.Core.Services
{
    /// <summary>
    /// Custom http client handler for FFImageLoading to support bearer tokens
    /// </summary>
    public class AuthenticatedHttpImageClientHandler: HttpClientHandler
    {
        private readonly Func<string> _getToken;

        public AuthenticatedHttpImageClientHandler(Func<string> generateToken)
        {
            _getToken = generateToken ?? throw new ArgumentNullException("generateToken");
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Authorization", "Bearer " + _getToken());
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
