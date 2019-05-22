using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("Teachers", Schema = "School")]
    public class Teacher : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        public virtual int ApplicationUserId { get; set; }
        public virtual ApplicationUser  ApplicationUser { get; set; }

        public virtual ICollection<SubjectAssingment> SubjectAssingments { get; set; }

    }
}
