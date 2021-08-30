using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class User : IUser
    {
        public string UserId { get; set; }

        public string ContactId { get; set; }
    }
}
