using Newtonsoft.Json;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("Classes", Schema = "School")]
    public class Class : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50), Display(Name = "División", Order = 2)]
        public string Name { get; set; }
        
        [Display(Name = "Turno", Order = 3)]
        public ShiftTimeEnum Shift { get; set; }

        [Display(Name = "Año", Order = 1)]
        [ForeignKey("Grade")]
        public int GradeId { get; set; }

        //[JsonIgnore]
        [Display(Name = "Año", Order = 1)]
        public virtual Grade Grade { get; set; }
    }
}
