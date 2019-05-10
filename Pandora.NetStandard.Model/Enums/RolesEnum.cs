using Reinforced.Typings.Attributes;
using System.ComponentModel;

namespace Pandora.NetStandard.Model.Enums
{
    [TsEnum]
    public enum RolesEnum
    {
        [Description("Dev")]
        DEBUG = -1,
        [Description("Admin")]
        ADMINISTRADOR = 1,
        [Description("Super")]
        SUPERVISOR,
        [Description("Teacher")]
        TEACHER,
        [Description("Student")]
        STUDENT
    }
}
