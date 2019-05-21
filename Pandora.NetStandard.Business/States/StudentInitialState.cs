using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.States
{
    public sealed class StudentInitialState : StateManager
    {
        public StudentInitialState(IStudentStateSvc studentStateSvc) : base(studentStateSvc)
        {
        }

        public async override Task<bool> EnrollStudentAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            var newState = new StudentStateDto
            {
                AcademicState = StudentStateEnum.ENROLLED,
                DateFrom = DateTime.Now,
                StudentId = studentDto.Id,
                SubjectId = subjectDto.Id
            };

            var result = await _studentStateSvc.CreateAsync(newState);
            return StateManagerResponseHandler(result);
        }

        public override Task<bool> StoreAttendenceAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            throw new StateManagerException($"The student {studentDto.FullName} is not enrolled in {subjectDto.Name} yet.");
        }

        public override Task<bool> SaveExamsResultAsync(IList<ExamDto> examDtos)
        {
            throw new StateManagerException($"The student {examDtos[0].Student.FullName} is not enrolled in {examDtos[0].Subject.Name} yet.");
        }
    }
}
