using Pandora.NetStandard.Core.Interfaces;
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
        [MaxLength(100)]
        public virtual string Email { get; set; }
        [MaxLength(100)]
        public virtual string PhoneNumber { get; set; }

        public virtual string FullName { get; }

        public virtual Class Class { get; set; }
    }
}
