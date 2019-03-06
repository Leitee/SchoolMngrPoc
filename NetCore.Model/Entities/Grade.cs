using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Model.Entities
{
    [Table("Grades")]
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
