using AutoMapper;
using System.Collections.Generic;

namespace Pandora.NetStandard.Core.Mapper
{
    public abstract class GenericMapperCore<TConvertEntity, TResultEntity> : IMapperCore<TConvertEntity, TResultEntity>
    {
        public virtual IMapper CreateCustomMap()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TConvertEntity, TResultEntity>();
            }).CreateMapper();
        }

        public virtual TResultEntity MapEntity(TConvertEntity entity) 
        {
            if (entity == null) return default(TResultEntity);
            return CreateCustomMap().Map<TResultEntity>(entity);
        }

        public virtual IEnumerable<TResultEntity> MapEntity(IEnumerable<TConvertEntity> entity)
        {
            if (entity == null) return null;
            return CreateCustomMap().Map<List<TResultEntity>>(entity);
        }

        public virtual TConvertEntity MapToBaseClass(TResultEntity entity)
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TResultEntity, TConvertEntity>();
            })
            .CreateMapper()
            .Map<TConvertEntity>(entity);
        }
    }
}
