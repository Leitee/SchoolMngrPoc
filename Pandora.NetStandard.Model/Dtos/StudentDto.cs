using AutoMapper;
using Newtonsoft.Json;
using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System.Collections.Generic;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Student")]
    public sealed class StudentDto : Student
    {
        public StudentDto()
        {
            //StudentStates = new List<StudentStateDto>();
        }

        public sealed override int Id { get => base.Id; set => base.Id = value; }
        public sealed override string Address { get => base.Address; set => base.Address = value; }
        public sealed override string Obs { get => base.Obs; set => base.Obs = value; }

        public new UserDto ApplicationUser { get; set; }
        public new IEnumerable<AttendDto> Attends { get; set; }
        public new IEnumerable<ExamDto> Exams { get; set; }
        [JsonIgnore]
        public new IEnumerable<StudentStateDto> StudentStates { get; set; }
        public StudentStateDto ValidStudentState { get; set; }
        [IgnoreMap]
        public AttendDto TodayAttend { get; set; }
    }
}
