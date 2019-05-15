using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("StudentStates", Schema = "School")]
    public class StudentState : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual StudentStateEnum AcademicState { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        [Required]
        public virtual Student Student { get; set; }
        [Required]
        public virtual Subject Subject { get; set; }
        public virtual string Obs { get; set; }
    }
}
