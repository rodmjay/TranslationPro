#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using TranslationPro.Base.Common.Settings;

namespace TemplateClient
{
    public class Worker : BackgroundService
    {
        private readonly string _audience;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly ILogger<Worker> _logger;
        private readonly AppSettings _settings;

        public Worker(ILogger<Worker> logger, IOptions<AppSettings> options, IConfiguration configuration)
        {
            _logger = logger;
            _settings = options.Value;

            _clientId = configuration.GetValue<string>("AppSettings:ClientId");
            _clientSecret = configuration.GetValue<string>("AppSettings:ClientSecret");
            _audience = configuration.GetValue<string>("AppSettings:Audience");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // discover endpoints from metadata
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync(_settings.Authority, stoppingToken);
            if (disco.IsError) Console.WriteLine(disco.Error);

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                Scope = _audience
            }, stoppingToken);

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync(_settings.IdentityEndpoint, stoppingToken);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync(stoppingToken);
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}