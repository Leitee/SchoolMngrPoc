using AutoMapper;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Pandora.NetStandard.Business.Mappers
{
    public class SubjectToDtoMapper : GenericMapperCore<Subject, SubjectDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<Subject, SubjectDto>()
                .ForMember(m => m.ValidSubjectAssingment, o => o.MapFrom(s => s.SubjectAssingments.SingleOrDefault(sa => !sa.Deleted)))
                .ForMember(m => m.ValidStudentState, o => o.MapFrom(s => s.StudentStates.SingleOrDefault(ss => !ss.DateTo.HasValue)));

                c.CreateMap<List<SubjectAssingment>, List<SubjectAssingmentDto>>();
                c.CreateMap<ApplicationUser, UserDto>();
                c.CreateMap<Teacher, TeacherDto>();
                c.CreateMap<Class, ClassDto>();

            }).CreateMapper();
        }
    }
}
