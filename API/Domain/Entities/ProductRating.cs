namespace API.Domain.Entities {
    /// <summary>
    /// This joint table stablishes the many to many relationship in between Product and Rating.
    /// By defining it in our entities we declare what navigation properties this table will have and what constraints EF
    /// will have to handle.
    /// </summary>
    public class ProductRating {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        
        public int RatingId { get; set; }
        public Rating Rating { get; set; } = null!;
        
    }
}
