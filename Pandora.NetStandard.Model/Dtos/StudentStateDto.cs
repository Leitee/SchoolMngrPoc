using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandora.NetStandard.Model.Dtos
{
    public class StudentStateDto : StudentState
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override StudentStateEnum AcademicState { get => base.AcademicState; set => base.AcademicState = value; }
        public override Student Student { get => base.Student; set => base.Student = value; }
        public override Subject Subject { get => base.Subject; set => base.Subject = value; }
        public override string Obs { get => base.Obs; set => base.Obs = value; }
    }
}
