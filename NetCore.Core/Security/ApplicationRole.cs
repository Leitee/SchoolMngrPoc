using Microsoft.AspNetCore.Identity;

namespace NetCore.Core.Security.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }

        public ApplicationRole(string name, string description) : base(name)
        {
            _description = description;
        }

        private string _description;
        public string Description { get;}
    }
}
