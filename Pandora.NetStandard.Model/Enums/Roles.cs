using Pandora.NetStandard.Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pandora.NetStandard.Model.Enums
{
    public enum RolesEnum
    {
        [Description("Dev")]
        DEBUG = 0,
        [Description("Admin")]
        ADMINISTRADOR,
        [Description("Super")]
        SUPERVISOR,
        [Description("Teacher")]
        TEACHER       
    }
    
}
