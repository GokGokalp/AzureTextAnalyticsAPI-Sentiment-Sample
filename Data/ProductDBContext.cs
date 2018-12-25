using Microsoft.EntityFrameworkCore;
using SentimentAnalysisWithNETCoreExample.Models.Domain;

namespace SentimentAnalysisWithNETCoreExample.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Products
            var product_1 = new Product()
            {
                ID = 1,
                Name = "Samsung Note 9",
                Category = "Cell Phones",
                Price = 600
            };

            var product_2 = new Product()
            {
                ID = 2,
                Name = "Samsung Galaxy 9",
                Category = "Cell Phones",
                Price = 550
            };

            modelBuilder.Entity<Product>().HasData(product_1, product_2);
            #endregion

            #region Comments
            var comment_1 = new Comment()
            {
                ID = 1,
                ProductID = 1,
                Content = "It's a great cell phone. I would recommend it to everyone."
            };

            var comment_2 = new Comment()
            {
                ID = 2,
                ProductID = 1,
                Content = "Nice phone, very useful."
            };

            var comment_3 = new Comment()
            {
                ID = 3,
                ProductID = 1,
                Content = "I like it."
            };

            var comment_4 = new Comment()
            {
                ID = 4,
                ProductID = 1,
                Content = "I highly recommend, the phone's battery very well."
            };

            var comment_5 = new Comment()
            {
                ID = 5,
                ProductID = 2,
                Content = "Not bad, it's getting a little warm. It could be better."
            };

            var comment_6 = new Comment()
            {
                ID = 6,
                ProductID = 2,
                Content = "I don't like the back cover, It slipping from my hand."
            };

            var comment_7 = new Comment()
            {
                ID = 7,
                ProductID = 2,
                Content = "I like it, not bad."
            };

            var comment_8 = new Comment()
            {
                ID = 8,
                ProductID = 2,
                Content = "I don't like the night shooting of this phone."
            };

            modelBuilder.Entity<Comment>().HasData(comment_1, comment_2, comment_3, comment_4, comment_5, comment_6, comment_7, comment_8);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}