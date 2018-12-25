namespace SentimentAnalysisWithNETCoreExample.Models.Requests
{
    public class GetSentimentAnalysisRequestItem
    {
        public string Language { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}