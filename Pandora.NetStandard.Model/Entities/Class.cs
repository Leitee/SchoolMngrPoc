using Newtonsoft.Json;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Enums;
using System.Collections.Generic;
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

        public virtual int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual int? ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
