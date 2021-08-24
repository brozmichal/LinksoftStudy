using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinksoftStudy.Data.Models
{
    [Table("ContactContactee")]
    public class ContactContacteeEntity : BaseEntity
    {
        public int ContactId { get; set; }
        public int ContacteeId { get; set; }

        public virtual PersonEntity Contact { get; set; }
        public virtual PersonEntity Contactee { get; set; }
    }
}
