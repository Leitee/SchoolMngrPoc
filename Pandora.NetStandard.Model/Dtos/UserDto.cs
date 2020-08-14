using AutoMapper;
using Pandora.NetStdLibrary.Base.Identity;
using Reinforced.Typings.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "User")]
    public sealed class UserDto : ApplicationUser
    {
        public UserDto()
        {
        }
        public UserDto(string pUsername, string pEmail, string pFirstName, string pLastName)
            : base(pUsername, pEmail, pFirstName, pLastName)
        {
        }

        public override int Id { get; set; }

        [Display(Name = "User Name")]
        public override string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [Display(Name = "Phone Number")]
        public override string PhoneNumber { get; set; }

        [Display(Name = "First Name")]
        public override string FirstName { get; set; }

        [Display(Name = "Second Name")]
        public override string LastName { get; set; }

        [Display(Name = "Full Name")]
        public new string FullName { get; set; }

        [Display(Name = "Join Date")]
        public override DateTime JoinDate { get { return base.JoinDate; } }
        [IgnoreMap]
        public RoleDto Role { get; set; }

        #region Security Identity fields Hidden
        [TsIgnore]
        public override string NormalizedUserName { set { } }
        [TsIgnore]
        public override string NormalizedEmail { set { } }
        [TsIgnore]
        public override string PasswordHash { set => base.PasswordHash = null; }
        [TsIgnore]
        public override bool EmailConfirmed { set { } }
        [TsIgnore]
        public override string SecurityStamp { set { } }
        [TsIgnore]
        public override string ConcurrencyStamp { set { } }
        [TsIgnore]
        public override bool PhoneNumberConfirmed { set { } }
        [TsIgnore]
        public override bool TwoFactorEnabled { set { } }
        [TsIgnore]
        public override DateTimeOffset? LockoutEnd { set { } }
        [TsIgnore]
        public override bool LockoutEnabled { set { } }
        [TsIgnore]
        public override int AccessFailedCount { set { } }
        #endregion
    }
}
