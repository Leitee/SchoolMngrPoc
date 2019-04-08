using Pandora.NetStandard.Core.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Business.Dtos
{
    public class RoleDto : ApplicationRole
    {
        public override int Id { get; set; }
        [Display(Name = "Role Name")]
        public override string Name { get; set; }
        public override string Description { get; set; }

        #region Security Identity fields Hidden
        public override string ConcurrencyStamp { set { } }
        public override string NormalizedName { set { } }
        #endregion
    }
}
