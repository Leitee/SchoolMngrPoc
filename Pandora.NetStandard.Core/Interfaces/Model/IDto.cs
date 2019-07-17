using System;
using System.Collections.Generic;
using System.Text;

namespace Pandora.NetStandard.Core.Interfaces.Model
{
    public interface IDto<TEntity> where TEntity : IEntity
    {
        TEntity BaseEntity { get; set; }
    }
}
