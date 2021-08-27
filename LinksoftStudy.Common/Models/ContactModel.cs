using LinksoftStudy.Common.Interfaces;

namespace LinksoftStudy.Common.Models
{
    public class ContactModel : IContactModel
    {
        public string ContactPrimary { get; set; }

        public string ContactSecondary { get; set; }
    }
}
