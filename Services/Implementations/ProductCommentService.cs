using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SentimentAnalysisWithNETCoreExample.Data;
using SentimentAnalysisWithNETCoreExample.Models.Domain;
using SentimentAnalysisWithNETCoreExample.Models.Requests;
using SentimentAnalysisWithNETCoreExample.Models.Responses;

namespace SentimentAnalysisWithNETCoreExample.Services.Implementations
{
    public class ProductCommentService : IProductCommentService
    {
        private const string LANG = "en";
        private readonly ProductDBContext _productDBContext;
        private readonly ITextAnalyticsService _textAnalyticsService;

        public ProductCommentService(ProductDBContext productDBContext, ITextAnalyticsService textAnalyticsService)
        {
            _productDBContext = productDBContext;
            _textAnalyticsService = textAnalyticsService;
        }

        public async Task<List<Comment>> GetComments(int productId)
        {
            List<Comment> comments = await _productDBContext.Comments.Where(c => c.ProductID == productId)
                                        .ToListAsync();

            return comments;
        }

        public async Task<List<Comment>> CalculateCommentsSentimentScoreAsync(List<Comment> comments)
        {
            var getSentimentAnalysisRequest = new GetSentimentAnalysisRequest();

            comments.ForEach(comment =>
            {
                var multiLanguageInput = new GetSentimentAnalysisRequestItem()
                {
                    Language = LANG,
                    Id = comment.ID.ToString(),
                    Text = comment.Content
                };

                getSentimentAnalysisRequest.Documents.Add(multiLanguageInput);
            });

            GetSentimentAnalysisResponse getSentimentAnalysisResponse = await _textAnalyticsService.GetSentimentAsync(getSentimentAnalysisRequest);

            if (getSentimentAnalysisResponse != null && getSentimentAnalysisResponse.Documents.Count > 0)
            {
                // Add sentiment analysis result to the comments
                foreach (GetSentimentAnalysisResponseItem getSentimentAnalysisResponseItem in getSentimentAnalysisResponse.Documents)
                {
                    Comment comment = comments.FirstOrDefault(c => c.ID == Convert.ToInt32(getSentimentAnalysisResponseItem.Id));

                    comment.SentimentScore = getSentimentAnalysisResponseItem.Score;
                }
            }

            return comments;
        }
    }
}