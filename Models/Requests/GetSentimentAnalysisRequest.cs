using System.Collections.Generic;

namespace SentimentAnalysisWithNETCoreExample.Models.Requests
{
    public class GetSentimentAnalysisRequest
    {
        public GetSentimentAnalysisRequest()
        {
            Documents = new List<GetSentimentAnalysisRequestItem>();
        }

        public IList<GetSentimentAnalysisRequestItem> Documents { get; set; }
    }
}