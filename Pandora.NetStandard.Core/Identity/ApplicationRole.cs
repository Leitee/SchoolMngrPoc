using Microsoft.AspNetCore.Identity;

namespace Pandora.NetStandard.Core.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() { }
        public ApplicationRole(string name, string description) : base(name)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
