using Pandora.NetStandard.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.NetStandard.Model.Entities
{
    [Table("Subjects", Schema = "School")]
    public class Subject : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual IEnumerable<Subject> PreReqSubjects { get; set; }
        public virtual int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual IEnumerable<StudentState> SubjectStates { get; set; }

        public virtual IEnumerable<Attend> Attends { get; set; }
        public virtual IEnumerable<Exam> Exams { get; set; }

        #region subject constrains

        public static int MaxAttendenceAllowed { get { return 2; } }
        public static int MinExamScoreRequired { get { return 6; } }

        #endregion
    }
}
