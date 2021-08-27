using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinksoftStudy.Data.Models
{
    [Table("ContactContactee")]
    public class ContactContacteeEntity : BaseEntity
    {
        public int ContactId { get; set; }
        public int ContacteeId { get; set; }

        public PersonEntity Contact { get; set; }
        public PersonEntity Contactee { get; set; }
    }
}
