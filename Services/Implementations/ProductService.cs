using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SentimentAnalysisWithNETCoreExample.Data;
using SentimentAnalysisWithNETCoreExample.Models.Domain;
using SentimentAnalysisWithNETCoreExample.Models.Responses;

namespace SentimentAnalysisWithNETCoreExample.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ProductDBContext _productDBContext;
        private readonly IProductCommentService _productCommentService;

        public ProductService(ProductDBContext productDBContext, IProductCommentService productCommentService)
        {
            _productDBContext = productDBContext;
            _productCommentService = productCommentService;
        }

        public async Task<GetProductResponse> GetProductAsync(int id)
        {
            Product product =  await _productDBContext.Products.Where(p => p.ID == id)
                                    .FirstOrDefaultAsync();

            GetProductResponse productResponse = null;

            if (product != null)
            {
                productResponse = new GetProductResponse();
                
                productResponse.ID = product.ID;
                productResponse.Name = product.Name;
                productResponse.Category = product.Category;
                productResponse.Price = product.Price;

                List<Comment> comments = await _productCommentService.GetComments(id);

                productResponse.Comments = comments.Select(c => new GetProductCommentResponse()
                {
                    Content = c.Content
                }).ToList();

                if (comments.Count > 0)
                {
                    List<Comment> commentsWithSentimentAnalysis = await _productCommentService.CalculateCommentsSentimentScoreAsync(comments);

                    productResponse.CustomerRating = await CalculateProductCustomerRatingScore(commentsWithSentimentAnalysis);
                }
            }

            return productResponse;
        }

        private async Task<double> CalculateProductCustomerRatingScore(List<Comment> comments)
        {
            double sentimentScores = 0;
            double customerRating = 0;

            comments.ForEach(_comment =>
            {
                sentimentScores += _comment.SentimentScore.Value;
            });

            customerRating = (sentimentScores / comments.Count());

            return await Task.FromResult(customerRating);
        }
    }
}