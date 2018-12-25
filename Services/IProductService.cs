using System.Collections.Generic;
using System.Threading.Tasks;
using SentimentAnalysisWithNETCoreExample.Models.Domain;
using SentimentAnalysisWithNETCoreExample.Models.Responses;

namespace SentimentAnalysisWithNETCoreExample.Services
{
    public interface IProductService
    {
         Task<GetProductResponse> GetProductAsync(int id);
    }
}