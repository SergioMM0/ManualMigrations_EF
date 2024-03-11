namespace API.Domain.Entities {
    public class Rating {
        public int Id { get; set; }
        public double Value { get; set; }
        public ICollection<ProductRating> ProductRatings { get; set; } = new List<ProductRating>();

    }
}
