using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System.Collections.Generic;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Subject")]
    public sealed class SubjectDto : Subject
    {
        public SubjectDto()
        {
            PreReqSubjects = new List<SubjectDto>();
            Exams = new List<ExamDto>();
            Attends = new List<AttendDto>();
        }

        public override int Id { get => base.Id; set => base.Id = value; }
        public override string Name { get => base.Name; set => base.Name = value; }
        public new IEnumerable<SubjectDto> PreReqSubjects { get; set; }
        public new IEnumerable<AttendDto> Attends { get; set; }
        public new IEnumerable<ExamDto> Exams { get; set; }
    }
}
