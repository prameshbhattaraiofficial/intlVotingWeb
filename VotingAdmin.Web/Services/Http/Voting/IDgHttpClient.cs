using System.Net;

namespace VotingAdmin.Web.Services.Http.Voting
{
    public interface IDgHttpClient
    {
        HttpClient GetHttpClient();
        Task<(HttpStatusCode statusCode, T responseType)> GetAsync<T>(string requestUri);
        Task<(HttpStatusCode statusCode, T responseType)> PostAsync<T>(string requestUri, HttpContent content);
        Task<(HttpStatusCode statusCode, T responseType)> PutAsync<T>(string requestUri, HttpContent content);
        Task<(HttpStatusCode statusCode, T responseType)> DeleteAsync<T>(string requestUri);
    }
}
