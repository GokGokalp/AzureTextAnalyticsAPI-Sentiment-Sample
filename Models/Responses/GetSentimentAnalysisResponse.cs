using System.Collections.Generic;

namespace SentimentAnalysisWithNETCoreExample.Models.Responses
{
    public class GetSentimentAnalysisResponse
    {
        public IList<GetSentimentAnalysisResponseItem> Documents { get; set; }
    }
}