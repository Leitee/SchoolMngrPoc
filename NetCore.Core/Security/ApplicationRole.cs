using Microsoft.AspNetCore.Identity;
using System;

namespace NetCore.Core.Security.Identity
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
