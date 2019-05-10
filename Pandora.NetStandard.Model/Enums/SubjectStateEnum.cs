using Reinforced.Typings.Attributes;
using System.ComponentModel;

namespace Pandora.NetStandard.Model.Enums
{
    [TsEnum]
    public enum SubjectStateEnum
    {
        [Description("Matriculado")]
        SUBSCRIBED,
        [Description("Aprobado")]
        ACCOMPLISHED,
        [Description("Regular")]
        IN_PROGRESS,
        [Description("Irregular")]
        ABANDONED
    }
}
