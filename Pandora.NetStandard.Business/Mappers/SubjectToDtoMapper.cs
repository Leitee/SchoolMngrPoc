using AutoMapper;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using System.Linq;

namespace Pandora.NetStandard.Business.Mappers
{
    public class SubjectToDtoMapper : GenericMapper<Subject, SubjectDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<Subject, SubjectDto>()
                .ForMember(m => m.ValidSubjectAssingment, o => o.MapFrom(s => s.SubjectAssingments.SingleOrDefault(sa => !sa.Deleted)))
                .ForMember(m => m.ValidStudentState, o => o.MapFrom(s => s.StudentStates.SingleOrDefault(ss => !ss.DateTo.HasValue)));
                c.CreateMap<SubjectAssingment, SubjectAssingmentDto>();
                c.CreateMap<ApplicationUser, UserDto>();
                c.CreateMap<Teacher, TeacherDto>();
                c.CreateMap<Class, ClassDto>();
                c.CreateMap<ClassRoom, ClassRoomDto>();
                c.CreateMap<Attend, AttendDto>();
                c.CreateMap<Exam, ExamDto>();
            })
            .CreateMapper();
        }
    }
}
