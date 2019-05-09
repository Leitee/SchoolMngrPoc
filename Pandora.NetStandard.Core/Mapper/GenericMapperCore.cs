using AutoMapper;
using System.Collections.Generic;

namespace Pandora.NetStandard.Core.Mapper
{
    public abstract class GenericMapperCore<TInputEntity, TOutputEntity> : IMapperCore<TInputEntity, TOutputEntity>
    {
        protected IMapper MappingConfiguration { get; set; }

        public GenericMapperCore()
        {
            MappingConfiguration = DefaultMapConfiguration();
        }

        protected virtual IMapper DefaultMapConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TInputEntity, TOutputEntity>();
            }).CreateMapper();
        }

        public virtual void SetMapperConfiguration(IMapperConfigurationExpression configurationExpression)
        {
            //TODO: add expression param functionaity
            var test = configurationExpression;
        }

        public virtual void SetMapperConfiguration(IMapper pMapperConfig)
        {
            MappingConfiguration = pMapperConfig;
        }

        public virtual TOutputEntity MapEntity(TInputEntity entity) 
        {
            if (entity == null) return default;
            return MappingConfiguration.Map<TOutputEntity>(entity);
        }

        public virtual IEnumerable<TOutputEntity> MapEntity(IEnumerable<TInputEntity> entity)
        {
            if (entity == null) return null;
            return MappingConfiguration.Map<IEnumerable<TOutputEntity>>(entity);
        }
    }

    public class GenericMapperCore : IMapperCore
    {
        protected virtual IMapper CreateCustomMap<TInputEntity, TOutputEntity>()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TInputEntity, TOutputEntity>();
            }).CreateMapper();
        }

        public virtual TOutputEntity MapEntity<TInputEntity, TOutputEntity>(TInputEntity pEntity, IMapper pMapperConfig = null)
        {
            if (pEntity == null) return default;
            var mapper = pMapperConfig ?? CreateCustomMap<TInputEntity, TOutputEntity>();
            return mapper.Map<TOutputEntity>(pEntity);
        }

        public virtual IEnumerable<TOutputEntity> MapEntity<TInputEntity, TOutputEntity>(IEnumerable<TInputEntity> pEntities, IMapper pMapperConfig = null)
        {
            if (pEntities == null) return null;
            var mapper = pMapperConfig ?? CreateCustomMap<TInputEntity, TOutputEntity>();
            return mapper.Map<IEnumerable<TOutputEntity>>(pEntities);
        }

        public virtual TBaseClass MapToBaseClass<TDerivedClass, TBaseClass>(TDerivedClass pEntity)
        {
            if (pEntity == null) return default;
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TDerivedClass, TBaseClass>();
            })
            .CreateMapper()
            .Map<TBaseClass>(pEntity);
        }

        public virtual IEnumerable<TBaseClass> MapToBaseClass<TDerivedClass, TBaseClass>(IEnumerable<TDerivedClass> pEntities)
        {
            if (pEntities == null) return null;
            return new MapperConfiguration(c =>
            {
                c.CreateMap<TDerivedClass, TBaseClass>();
            })
            .CreateMapper()
            .Map<IEnumerable<TBaseClass>>(pEntities);
        }
    }
}
