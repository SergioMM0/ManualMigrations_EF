namespace API.Domain.Entities {
    
    public class Blog {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required int PriceOfSubscription { get; set; }
        public required List<Comment> Comments { get; set; }
    }
}
