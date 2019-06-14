using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.States
{
    public sealed class StudentEnrolledState : StateManager
    {
        public StudentEnrolledState(IStudentStateSvc studentStateSvc) : base(studentStateSvc)
        {
        }

        public override Task<bool> EnrollStudentAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            throw new StateManagerException($"The student {studentDto.ApplicationUser.FullName} is already enrolled in {subjectDto.Name}.");
        }

        public override Task<bool> StoreAttendenceAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            throw new NotImplementedException();
        }

        public async override Task<bool> SaveExamsResultAsync(IList<ExamDto> examDtos)
        {
            var lastState = _studentStateSvc.GetLastValidStateAsync(examDtos.FirstOrDefault().StudentId, examDtos.FirstOrDefault().SubjectId).Result.Data;
            lastState.DateTo = DateTime.Now;
            await _studentStateSvc.UpdateAsync(lastState);

            var newState = new StudentStateDto
            {
                AcademicState = StudentStateEnum.ACTIVE,
                DateFrom = DateTime.Now,
                SubjectId = examDtos.FirstOrDefault().SubjectId,
                StudentId = examDtos.FirstOrDefault().StudentId
            };

            var resul = await _studentStateSvc.CreateAsync(newState);
            return StateManagerResponseHandler(resul);
        }
    }
}
