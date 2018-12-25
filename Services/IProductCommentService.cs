using System.Collections.Generic;
using System.Threading.Tasks;
using SentimentAnalysisWithNETCoreExample.Models.Domain;

namespace SentimentAnalysisWithNETCoreExample.Services
{
    public interface IProductCommentService
    {
        Task<List<Comment>> GetComments(int productId);
        Task<List<Comment>> CalculateCommentsSentimentScoreAsync(List<Comment> comments);
    }
}