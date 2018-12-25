using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SentimentAnalysisWithNETCoreExample.Models.Requests;
using SentimentAnalysisWithNETCoreExample.Models.Responses;

namespace SentimentAnalysisWithNETCoreExample.Services.Implementations
{
    public class TextAnalyticsService : ITextAnalyticsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public TextAnalyticsService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<GetSentimentAnalysisResponse> GetSentimentAsync(GetSentimentAnalysisRequest request)
        {
            HttpClient client = _httpClientFactory.CreateClient("TextAnalyticsAPI");

            var sentimentResponse = await client.PostAsJsonAsync(
                    requestUri: _configuration.GetValue<string>("TextAnalyticsAPISentimentResourceURI"), 
                    value: request);

            GetSentimentAnalysisResponse getSentimentAnalysisResponse = null;

            if(sentimentResponse.StatusCode == HttpStatusCode.OK)
            {
                getSentimentAnalysisResponse = await sentimentResponse.Content.ReadAsAsync<GetSentimentAnalysisResponse>();
            }

            return getSentimentAnalysisResponse;
        }
    }
}