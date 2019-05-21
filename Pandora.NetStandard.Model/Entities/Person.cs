using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Model.Entities
{
    public abstract class Person
    {
        [Required, MaxLength(100)]
        public virtual string FirstName { get; set; }
        [Required, MaxLength(100)]
        public virtual string LastName { get; set; }
        [MaxLength(100)]
        public virtual string Email { get; set; }
        [MaxLength(100)]
        public virtual string PhoneNumber { get; set; }
        [MaxLength(200)]
        public virtual string Address { get; set; }

        public virtual string FullName { get { return $"{LastName.ToUpper()} {FirstName}"; } }
    }
}
