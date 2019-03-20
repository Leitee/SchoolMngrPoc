using Newtonsoft.Json;
using Pandora.NetStandard.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required, MaxLength(50), Display(Name = "Nombre")]
        public string Name { get; set; }
        
        public ShiftTimeEnum Shift { get; set; }

        [ForeignKey("Grade")]
        public int GradeId { get; set; }

        //[JsonIgnore]
        public virtual Grade Grade { get; set; }
    }
}
