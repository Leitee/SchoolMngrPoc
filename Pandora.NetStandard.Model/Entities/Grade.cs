using Pandora.NetStandard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("Grades", Schema = "School")]
    public class Grade : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, MaxLength(50), Display(Name = "Año", Order = 1)]
        public string Name { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
