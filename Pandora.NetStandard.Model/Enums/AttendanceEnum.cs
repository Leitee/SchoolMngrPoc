using Reinforced.Typings.Attributes;
using System.ComponentModel;

namespace Pandora.NetStandard.Model.Enums
{
    [TsEnum]
    public enum AttendanceEnum
    {
        [Description("Presente")]
        ATTEND = 1,
        [Description("Ausente")]
        MISS = 2,
        [Description("Justificado")]
        REASON = 3,
    }
}
