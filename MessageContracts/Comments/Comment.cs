using System;

namespace MessageContracts.Comments
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guest Author { get; set; }
        public CommentType CommentType { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool Resolved { get; set; }
    }
}