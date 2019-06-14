using Newtonsoft.Json;
using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System.Collections.Generic;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Teacher")]
    public sealed class TeacherDto : Teacher
    {
        public sealed override int Id { get => base.Id; set => base.Id = value; }
        public sealed override string Address { get => base.Address; set => base.Address = value; }
        public sealed override string Obs { get => base.Obs; set => base.Obs = value; }

        public new UserDto ApplicationUser { get; set; }
        public SubjectAssingmentDto ValidSubjectAssingment { get; set; }
        [JsonIgnore]
        public new IEnumerable<SubjectAssingmentDto> SubjectAssingments { get; set; }
    }
}
