using Newtonsoft.Json;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using Reinforced.Typings.Attributes;
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

        //[JsonIgnore]
        [Display(Name = "Año", Order = 1)]
        public new GradeDto Grade { get; set; }
    }
}
