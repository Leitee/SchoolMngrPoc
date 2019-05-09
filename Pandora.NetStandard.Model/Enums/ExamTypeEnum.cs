using Reinforced.Typings.Attributes;
using System.ComponentModel;

namespace Pandora.NetStandard.Model.Enums
{
    [TsEnum]
    public enum ExamTypeEnum
    {
        [Description("Primer")]
        FIRST = 1,
        [Description("Segundo")]
        SECOND = 2,
        [Description("Tercer")]
        THIRD = 3,
        [Description("Recuperatorio")]
        RETRY = 4,
        [Description("Final")]
        FINAL = 5
    }
}
