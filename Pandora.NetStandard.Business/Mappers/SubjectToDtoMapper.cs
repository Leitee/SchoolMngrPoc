using AutoMapper;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;

namespace Pandora.NetStandard.Business.Mappers
{
    public class SubjectToDtoMapper : GenericMapperCore<Subject, SubjectDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<Subject, SubjectDto>();
                c.CreateMap<SubjectAssingment, SubjectAssingmentDto>();
                c.CreateMap<Class, ClassDto>();

            }).CreateMapper();
        }
    }
}
