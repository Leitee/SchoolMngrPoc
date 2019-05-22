using Pandora.NetStandard.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("SubjectAssingments", Schema = "School")]
    public class SubjectAssingment : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual DateTime Date { get; set; }
        public virtual bool Disable { get; set; }
        public virtual int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual int ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual int? ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public virtual int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
