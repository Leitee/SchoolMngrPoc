using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "SubjectAssingment")]
    public sealed class SubjectAssingmentDto : SubjectAssingment
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override DateTime Date { get => base.Date; set => base.Date = value; }
        public override bool Disable { get => base.Disable; set => base.Disable = value; }
        public override int SubjectId { get => base.SubjectId; set => base.SubjectId = value; }
        public new SubjectDto Subject { get; set; }
        public override int ClassId { get => base.ClassId; set => base.ClassId = value; }
        public new Class Class { get; set; }
        public override int? ClassRoomId { get => base.ClassRoomId; set => base.ClassRoomId = value; }
        public new ClassRoom ClassRoom { get; set; }
        public override int? TeacherId { get => base.TeacherId; set => base.TeacherId = value; }
        public new Teacher Teacher { get; set; }
    }
}
