using AutoMapper;
using System.Collections.Generic;

namespace Pandora.NetStandard.Core.Mapper
{
    public abstract class GenericMapperCore<TConvertEntity, TResultEntity> : IMapperCore<TConvertEntity, TResultEntity>
    {
        public virtual IMapper CreateMap()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TConvertEntity, TResultEntity>();
            }).CreateMapper();
        }

        public virtual TResultEntity MapEntity(TConvertEntity entity) 
        {
            if (entity == null) return default(TResultEntity);
            return CreateMap().Map<TResultEntity>(entity);
        }

        public virtual IEnumerable<TResultEntity> MapEntity(IEnumerable<TConvertEntity> entity)
        {
            if (entity == null) return null;
            return CreateMap().Map<List<TResultEntity>>(entity);
        }
    }
}
