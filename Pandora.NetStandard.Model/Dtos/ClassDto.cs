using Newtonsoft.Json;
using Pandora.NetStdLibrary.Base.Utils;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using Reinforced.Typings.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Class")]
    public  sealed class ClassDto : Class
    {
        public override int Id { get; set; }

        [Required, MaxLength(50), Display(Name = "División", Order = 2)]
        public override string Name { get; set; }

        [Display(Name = "Turno", Order = 3)]
        public override ShiftTimeEnum Shift { get; set; }

        public string ShiftDescription { get { return Shift.GetDescription(); } }

        [Display(Name = "Año", Order = 1)]
        public new GradeDto Grade { get; set; }

        public SubjectAssingmentDto ValidSubjectAssingment { get; set; }
        [JsonIgnore]
        public new IEnumerable<SubjectAssingmentDto> SubjectAssingments { get; set; }
    }
}
