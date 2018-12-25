using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisWithNETCoreExample.Models.Domain;
using SentimentAnalysisWithNETCoreExample.Models.Responses;
using SentimentAnalysisWithNETCoreExample.Services;

namespace SentimentAnalysisWithNETCoreExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            GetProductResponse product = await _productService.GetProductAsync(id);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}