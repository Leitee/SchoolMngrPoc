using Newtonsoft.Json;
using Pandora.NetStandard.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("Grades", Schema = "School")]
    public class Grade : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        [Required, MaxLength(50)]
        public virtual string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Class> Classes { get; set; }
    }
}
