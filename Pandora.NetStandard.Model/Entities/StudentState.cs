using Pandora.NetStandard.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("StudentStates", Schema = "School")]
    public class StudentState
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual SubjectStateEnum AcademicState { get; set; }
        [Required]
        public virtual Student Student { get; set; }
        [Required]
        public virtual Subject Subject { get; set; }
        public virtual string Obs { get; set; }
    }
}
