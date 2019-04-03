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
        public virtual int Id { get; set; }

        [Required, MaxLength(50)]
        public virtual string Name { get; set; }

        public virtual ShiftTimeEnum Shift { get; set; }

        [ForeignKey("Grade")]
        public int GradeId { get; set; }

        //[JsonIgnore]
        public virtual Grade Grade { get; set; }
    }
}
