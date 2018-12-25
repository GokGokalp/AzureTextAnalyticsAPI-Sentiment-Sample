namespace SentimentAnalysisWithNETCoreExample.Models.Domain
{
    public class Comment
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Content { get; set; }
        public double? SentimentScore { get; set; }
    }
}