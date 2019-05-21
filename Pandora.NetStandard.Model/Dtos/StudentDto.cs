using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Student")]
    public sealed class StudentDto : Student
    {
        public StudentDto()
        {
            SubjectStates = new List<StudentStateDto>();
        }

        public override int Id { get => base.Id; set => base.Id = value; }
        [MaxLength(50), Display(Name = "First Name")]
        public override string FirstName { get => base.FirstName; set => base.FirstName = value; }
        [MaxLength(50), Display(Name = "Last Name")]
        public override string LastName { get => base.LastName; set => base.LastName = value; }
        [MaxLength(50), DataType(DataType.EmailAddress)]
        public override string Email { get => base.Email; set => base.Email = value; }
        [MaxLength(50), DataType(DataType.PhoneNumber)]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [Display(Name = "Full Name")]
        public override string FullName => base.FullName;

        public override string Address { get => base.Address; set => base.Address = value; }
        public override int? ClassId { get => base.ClassId; set => base.ClassId = value; }
        public new ClassDto Class { get; set; }
        public new IEnumerable<StudentStateDto> SubjectStates { get; set; }
        public StudentStateDto StudentState { get; set; }
    }
}
