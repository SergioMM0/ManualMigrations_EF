namespace API.Domain.Entities {
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int Category_Id { get; set; } // Deleteable
        public Category Category { get; set; } = null!; // Reference to category
        public ICollection<ProductRating> ProductRatings { get; set; } = new List<ProductRating>(); // Reference to joint table

    }
}
