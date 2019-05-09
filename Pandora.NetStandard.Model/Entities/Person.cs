using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Model.Entities
{
    public class Person
    {
        [Required, MaxLength(100)]
        public virtual string FirstName { get; set; }
        [Required, MaxLength(100)]
        public virtual string LastName { get; set; }
        [MaxLength(100)]
        public virtual string Email { get; set; }
        [MaxLength(100)]
        public virtual string PhoneNumber { get; set; }

        public virtual string FullName { get { return $"{LastName.ToUpper()} {FirstName}"; } }
    }
}
