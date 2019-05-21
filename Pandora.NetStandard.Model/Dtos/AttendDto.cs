using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using Reinforced.Typings.Attributes;
using System;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Attend")]
    public sealed class AttendDto : Attend
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override AttendanceEnum Attendance { get => base.Attendance; set => base.Attendance = value; }
        public override DateTime Date { get => base.Date; set => base.Date = value; }
        public override string Obs { get => base.Obs; set => base.Obs = value; }
        public new StudentDto Student { get; set; }
        public new SubjectDto Subject { get; set; }
    }
}
