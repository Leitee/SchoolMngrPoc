using Newtonsoft.Json;
using Pandora.NetStandard.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Business.Dtos
{
    public class GradeDto : Grade
    {
        [Required]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Required, MaxLength(50), Display(Name = "Año", Order = 1)]
        public override string Name { get => base.Name; set => base.Name = value; }
        
        public new ICollection<ClassDto> Classes { set { } }
    }
}
