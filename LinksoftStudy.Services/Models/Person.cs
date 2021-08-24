using LinksoftStudy.Services.Interfaces;

namespace LinksoftStudy.Services.Models
{
    public class Person : IPerson
    {
        public string PersonId { get; set; }

        public string ContactId { get; set; }
    }
}
