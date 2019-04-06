using AutoMapper;
using System.Collections.Generic;

namespace Pandora.NetStandard.Core.Mapper
{
    public interface IMapperCore<in TInputEntity, out TOutputEntity>
    {
        void SetMapperConfiguration(IMapper pMapperConfig);
        TOutputEntity MapEntity(TInputEntity pEntity);
        IEnumerable<TOutputEntity> MapEntity(IEnumerable<TInputEntity> pEntities);
    }
    public interface IMapperCore
    {
        TOutputEntity MapEntity<TInputEntity, TOutputEntity>(TInputEntity pEntity, IMapper pMapperConfig = null);
        IEnumerable<TOutputEntity> MapEntity<TInputEntity, TOutputEntity>(IEnumerable<TInputEntity> pEntities, IMapper pMapperConfig = null);
        TBaseClass MapToBaseClass<TDerivedClass, TBaseClass>(TDerivedClass pEntity);
        IEnumerable<TBaseClass> MapToBaseClass<TDerivedClass, TBaseClass>(IEnumerable<TDerivedClass> pEntities);
    }
}
