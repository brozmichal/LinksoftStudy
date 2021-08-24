using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinksoftStudy.Data.Models
{
    [Table("People")]
    public class PersonEntity : BaseEntity
    {
        [Required]
        public string PersonId { get; set; }

        public virtual ICollection<ContactContacteeEntity> Contactee { get; set; }
        public virtual ICollection<ContactContacteeEntity> Contact { get; set; }
    }
}
