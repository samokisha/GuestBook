namespace MessageContracts.Comments
{
    public class NewCommentModel
    {
        public GuestModel Author { get; set; }
        public CommentTypeModel CommentType { get; set; }
        public string Text { get; set; }
    }
}