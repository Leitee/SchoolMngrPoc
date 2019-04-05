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

        public virtual string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
