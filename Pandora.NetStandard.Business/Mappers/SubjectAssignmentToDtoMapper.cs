using AutoMapper;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;

namespace Pandora.NetStandard.Business.Mappers
{
    public class SubjectAssignmentToDtoMapper : GenericMapperCore<SubjectAssingment, SubjectAssingmentDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return DefaultMapConfiguration();
        }
    }
}
