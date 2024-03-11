namespace API.Domain.Entities {
    /// <summary>
    /// This class was created without following the assignment's context...
    /// </summary>
    public class Comment {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public required string Signature { get; set; }
    }
}
