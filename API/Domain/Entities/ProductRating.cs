namespace API.Domain.Entities {
    public class ProductRating {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        
        public int RatingId { get; set; }
        public Rating Rating { get; set; } = null!;
        
    }
}
