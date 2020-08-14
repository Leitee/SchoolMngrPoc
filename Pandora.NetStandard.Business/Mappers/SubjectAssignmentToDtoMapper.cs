using AutoMapper;
using Pandora.NetStdLibrary.Base.Mapper;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;

namespace Pandora.NetStandard.Business.Mappers
{
    public class SubjectAssignmentToDtoMapper : GenericMapper<SubjectAssingment, SubjectAssingmentDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return DefaultMapConfiguration();
        }
    }
}
