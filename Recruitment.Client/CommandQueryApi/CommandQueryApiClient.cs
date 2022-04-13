using Recruitment.Client.CommandQueryApi.Requests;
using Recruitment.Client.CommandQueryApi.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Client.CommandQueryApi
{
    public class CommandQueryApiClient : ICommandQueryApiClient, IDisposable
    {
        private readonly HttpClient _client = new HttpClient();

        private bool isCurrentInstanceDisposed = false;

        private readonly string _baseAddress = null;

        public CommandQueryApiClient(string baseAddress = default(string))
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new ArgumentNullException(nameof(baseAddress), "Address parameter can not be null");
            }
            _baseAddress = baseAddress;
        }

        public CommandQueryApiClient(HttpClient client)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client), "Client parameter can not be null");
            }
            _client = client;
        }

        //Finalizer 
        ~CommandQueryApiClient()
        {
            Dispose(disposing: false);
        }

        public async Task<HashedResult> GenerateHashAsync(CalculateHashRequest request, CancellationToken cancellationToken = default)
        {
            PrepareClient();
            HttpResponseMessage response = await _client.PostAsJsonAsync("generate", request, cancellationToken);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            HashedResult result = await response.Content.ReadFromJsonAsync<HashedResult>(null);
            return result;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isCurrentInstanceDisposed)
            {
                return;
            }

            if (disposing)
            {
                _client?.Dispose();
            }

            isCurrentInstanceDisposed = true;
        }

        private void PrepareClient()
        {
            if (_client is null)
            {
                _client.BaseAddress = new Uri(_baseAddress);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
    }
}
