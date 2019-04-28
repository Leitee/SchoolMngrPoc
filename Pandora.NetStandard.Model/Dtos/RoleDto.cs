using Newtonsoft.Json;
using Pandora.NetStandard.Core.Identity;
using Reinforced.Typings.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "Role")]
    public class RoleDto : ApplicationRole
    {
        public override int Id { get; set; }
        [Display(Name = "Role Name")]
        public override string Name { get; set; }
        public override string Description { get; set; }

        #region Security Identity fields Hidden
        [TsIgnore]
        public override string ConcurrencyStamp { set { } }
        [TsIgnore]
        public override string NormalizedName { set { } }
        #endregion
    }
}
