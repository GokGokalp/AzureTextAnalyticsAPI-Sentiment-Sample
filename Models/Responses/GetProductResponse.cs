using System.Collections.Generic;

namespace SentimentAnalysisWithNETCoreExample.Models.Responses
{
    public class GetProductResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public double CustomerRating { get; set; }
        public List<GetProductCommentResponse> Comments { get; set; }
    }
}