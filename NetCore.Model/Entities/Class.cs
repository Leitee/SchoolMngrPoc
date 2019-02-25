using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Model.Entities
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }

        public int GradeId { get; set; }
        public Grade Garade { get; set; }
    }
}
