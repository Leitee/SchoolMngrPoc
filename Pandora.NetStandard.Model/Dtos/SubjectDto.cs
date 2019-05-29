using Newtonsoft.Json;
using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Subject")]
    public sealed class SubjectDto : Subject
    {
        public SubjectDto()
        {
            //Exams = new List<ExamDto>();
            //Attends = new List<AttendDto>();
            //StudentStates = new List<StudentStateDto>();
            //SubjectAssingments = new List<SubjectAssingmentDto>();
        }

        public override int Id { get => base.Id; set => base.Id = value; }
        public override string Name { get => base.Name; set => base.Name = value; }
        public SubjectAssingmentDto ValidSubjectAssingment { get; set; }
        public StudentStateDto ValidStudentState { get; set; }
        [JsonIgnore]
        public new IEnumerable<SubjectAssingmentDto> SubjectAssingments { get; set; }
        [JsonIgnore]
        public new IEnumerable<StudentStateDto> StudentStates { get; set; }
        public new IEnumerable<AttendDto> Attends { get; set; }
        public new IEnumerable<ExamDto> Exams { get; set; }

    }
}
