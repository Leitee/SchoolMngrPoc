using Pandora.NetStandard.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("Students", Schema = "School")]
    public class Student : IEntity //TODO look for using ApplicationUser as base class
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }
        [Required, MaxLength(100)]
        public virtual string FirstName { get; set; }
        [Required, MaxLength(100)]
        public virtual string LastName { get; set; }
        [MaxLength(100), EmailAddress]
        public virtual string Email { get; set; }
        [MaxLength(100), Phone]
        public virtual string PhoneNumber { get; set; }
        [MaxLength(200)]
        public virtual string Address { get; set; }
        public virtual string FullName { get { return $"{LastName.ToUpper()} {FirstName}"; } }

        public virtual ICollection<StudentState> SubjectStates { get; set; }
        public virtual ICollection<Attend> Attends { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
