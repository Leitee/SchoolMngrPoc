using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Subject")]
    public class SubjectDto : Subject
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string Name { get => base.Name; set => base.Name = value; }
        public override Teacher Teacher { get => base.Teacher; set => base.Teacher = value; }
        [TsIgnore]
        public override IEnumerable<Exam> Exams { get => base.Exams; set => base.Exams = value; }
    }
}
