using AutoMapper;
using Pandora.NetStandard.Core.Identity;
using Pandora.NetStandard.Core.Mapper;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Pandora.NetStandard.Business.Mappers
{
    public class StudentToDtoMapper : GenericMapper<Student, StudentDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<Student, StudentDto>()
                .ForMember(m => m.ValidStudentState, o => o.MapFrom(s => s.StudentStates.FirstOrDefault(ss => !ss.DateTo.HasValue)));

                c.CreateMap<StudentState, StudentStateDto>();
                c.CreateMap<ApplicationUser, UserDto>();
                c.CreateMap<Attend, AttendDto>();
                c.CreateMap<Exam, ExamDto>();

            })
            .CreateMapper();
        }
    }
}
