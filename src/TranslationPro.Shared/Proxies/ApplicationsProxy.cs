using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies
{
    public class ApplicationsProxy : BaseProxy, IApplicationsController
    {


        public ApplicationsProxy(HttpClient httpClient) : base(httpClient)
        {
        }
        
        public Task<ApplicationOutput> GetApplicationAsync(Guid applicationId)
        {
            return DoGet<ApplicationOutput>($"{ApplicationUrl}/{applicationId}");
        }

        public async Task<List<ApplicationOutput>> GetApplicationsAsync()
        {
            return await DoGet<List<ApplicationOutput>>($"{ApplicationUrl}");
        }

        public Task<Result> CreateApplicationAsync(ApplicationCreateOptions input)
        {
            return DoPost<ApplicationCreateOptions, Result>(ApplicationUrl, input);
        }

        public Task<Result> DeleteApplicationAsync(Guid applicationId)
        {
            return DoDelete<Result>($"{ApplicationUrl}/{applicationId}");
        }

        public Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationOptions input)
        {
            return DoPut<ApplicationOptions, Result>($"{ApplicationUrl}/{applicationId}", input);
        }
    }
}
