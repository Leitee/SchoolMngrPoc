using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCore.Model.Entities
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}
