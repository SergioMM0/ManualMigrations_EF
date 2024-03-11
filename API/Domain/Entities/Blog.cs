namespace API.Domain.Entities {
    /// <summary>
    /// This class was created without following the assignment's context...
    /// </summary>
    public class Blog {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required double PriceOfSubscription { get; set; }
        public required List<Comment> Comments { get; set; }
    }
}
