using NetCore.Model.Enums;
using Newtonsoft.Json;
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
        [ForeignKey("Grade")]
        public int GradeId { get; set; }

        [JsonIgnore]
        public virtual Grade Garade { get; set; }
    }
}
