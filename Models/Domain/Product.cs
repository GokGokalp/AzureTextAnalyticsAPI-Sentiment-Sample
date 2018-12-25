using System.Collections.Generic;

namespace SentimentAnalysisWithNETCoreExample.Models.Domain
{
    public class Product
    {
        public Product()
        {
            this.Comments = new List<Comment>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public double CustomerRating { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}