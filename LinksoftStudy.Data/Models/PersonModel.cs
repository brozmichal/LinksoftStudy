namespace LinksoftStudy.Data.Models
{
    public class PersonModel
    {
        public string PersonId { get; set; }

        public string ContactId { get; set; }

        public bool RequiresSecondRun { get; set; } = false;
    }
}
