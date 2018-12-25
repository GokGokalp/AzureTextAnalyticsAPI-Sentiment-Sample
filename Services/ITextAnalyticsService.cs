using System.Threading.Tasks;
using SentimentAnalysisWithNETCoreExample.Models.Requests;
using SentimentAnalysisWithNETCoreExample.Models.Responses;

namespace SentimentAnalysisWithNETCoreExample.Services
{
    public interface ITextAnalyticsService
    {
         Task<GetSentimentAnalysisResponse> GetSentimentAsync(GetSentimentAnalysisRequest request);
    }
}