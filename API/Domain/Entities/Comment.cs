namespace API.Domain.Entities {
    public class Comment {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public required string Signature { get; set; }
    }
}
