using Pandora.NetStandard.Core.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Business.Dtos
{
    class RoleDto : ApplicationRole
    {
        public override int Id { get; set; }
        [Display(Name = "Role Name")]
        public override string Name { get; set; }
        public override string Description { get; set; }
    }
}
