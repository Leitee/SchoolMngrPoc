using Pandora.NetStandard.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("Students", Schema = "School")]
    public class Student : Person, IEntity //TODO look for using ApplicationUser as base class
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        public virtual int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public virtual IEnumerable<StudentState> SubjectStates { get; set; }
    }
}
