using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using Reinforced.Typings.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Exam")]
    public class ExamDto : Exam
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override ExamTypeEnum ExamType { get => base.ExamType; set => base.ExamType = value; }
        public override float? Score { get => base.Score; set => base.Score = value; }
        public override DateTime? Date { get => base.Date; set => base.Date = value; }
        public override string Obs { get => base.Obs; set => base.Obs = value; }
        public override Student Student { get => base.Student; set => base.Student = value; }
        public override Subject Subject { get => base.Subject; set => base.Subject = value; }
    }
}
