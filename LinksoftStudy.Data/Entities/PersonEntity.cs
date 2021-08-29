using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinksoftStudy.Data.Models
{
    [Table("People")]
    public class PersonEntity : BaseEntity
    {
        public PersonEntity()
        {
            Contacts = new List<ContactContacteeEntity>();
            Contactees = new List<ContactContacteeEntity>();
        }

        [Required]
        public string PersonId { get; set; }

        public virtual ICollection<ContactContacteeEntity> Contactees { get; set; }
        public virtual ICollection<ContactContacteeEntity> Contacts { get; set; }
    }
}
