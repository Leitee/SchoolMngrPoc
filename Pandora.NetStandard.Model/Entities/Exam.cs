using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("Exams", Schema = "School")]
    public class Exam : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual ExamTypeEnum ExamType { get; set; }
        [Required]
        public virtual float Score { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual string Obs { get; set; }
        [Required]
        public virtual Student Student { get; set; }
        [Required]
        public virtual Subject Subject { get; set; }

    }
}
