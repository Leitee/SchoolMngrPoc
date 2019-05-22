using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System.Collections.Generic;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Teacher")]
    public sealed class TeacherDto : Teacher
    {
        public override int Id { get => base.Id; set => base.Id = value; }

        public new ICollection<SubjectAssingment> SubjectAssingments { get; set; }
    }
}
