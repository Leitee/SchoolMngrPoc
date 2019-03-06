using NetCore.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Model.Entities
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string Name { get; set; }
        public ShiftTimeEnum Shift { get; set; }
        public int GradeId { get; set; }

        [ForeignKey("GradeId")]
        public virtual Grade Garade { get; set; }
    }
}
