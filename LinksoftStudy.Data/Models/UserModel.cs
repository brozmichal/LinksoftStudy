namespace LinksoftStudy.Data.Models
{
    public class UserModel
    {
        public string UserId { get; set; }

        public string ContactId { get; set; }

        public bool RequiresSecondRun { get; set; } = false;
    }
}
