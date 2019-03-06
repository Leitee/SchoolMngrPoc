using System.ComponentModel;

namespace NetCore.Model.Enums
{
    public enum ShiftTimeEnum
    {
        [Description("Mañana")]
        TOMORROW = 1,
        [Description("Tarde")]
        AFTERNOON = 2,
        [Description("Noche")]
        NIGHT = 3
    }
}
