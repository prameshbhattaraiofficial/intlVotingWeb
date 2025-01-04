﻿using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace VotingAdmin.Web.Services.Http.Voting
{
    public class DgHttpClient : IDgHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DgHttpClient(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(HttpStatusCode statusCode, T responseType)> DeleteAsync<T>(string requestUri)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                requestUri = string.Empty;

            var httpClient = GetHttpClient();
            using var response = await httpClient.DeleteAsync(requestUri);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<T>(responseString);

            return (response.StatusCode, responseObj);
        }

        public async Task<(HttpStatusCode statusCode, T responseType)> GetAsync<T>(string requestUri)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                requestUri = string.Empty;

            var httpClient = GetHttpClient();
            using var response = await httpClient.GetAsync(requestUri);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<T>(responseString);

            return (response.StatusCode, responseObj);
        }

        public HttpClient GetHttpClient()
        {
            return CreateHttpClient();
        }

        public async Task<(HttpStatusCode statusCode, T responseType)> PostAsync<T>(string requestUri, HttpContent content)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                requestUri = string.Empty;

            var httpClient = GetHttpClient();
            using var response = await httpClient.PostAsync(requestUri, content);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<T>(responseString);

            return (response.StatusCode, responseObj);
        }

        public async Task<(HttpStatusCode statusCode, T responseType)> PutAsync<T>(string requestUri, HttpContent content)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
                requestUri = string.Empty;

            var httpClient = GetHttpClient();
            using var response = await httpClient.PutAsync(requestUri, content);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<T>(responseString);

            return (response.StatusCode, responseObj);
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient(VotingApiDefaults.HttpClientVotingApi);

            var accessToken = _httpContextAccessor.HttpContext.Request.Headers[VotingApiDefaults.HeaderVotingApiAccessToken];

            if (!string.IsNullOrWhiteSpace(accessToken))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return httpClient;
        }
    }
}
