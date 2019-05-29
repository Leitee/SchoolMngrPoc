using Newtonsoft.Json;
using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Student")]
    public sealed class StudentDto : Student
    {
        public StudentDto()
        {
            //StudentStates = new List<StudentStateDto>();
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

        public new IEnumerable<AttendDto> Attends { get; set; }
        public new IEnumerable<ExamDto> Exams { get; set; }
        [JsonIgnore]
        public new IEnumerable<StudentStateDto> StudentStates { get; set; }
        public StudentStateDto ValidStudentState { get; set; }

    }
}
