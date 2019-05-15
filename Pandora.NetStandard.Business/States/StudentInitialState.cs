using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.States
{
    public class StudentInitialState : StateManager
    {
        public StudentInitialState(IStudentStateSvc studentStateSvc) : base(studentStateSvc)
        {
        }

        public async override Task<bool> EnrollAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            var newState = new StudentStateDto
            {
                AcademicState = StudentStateEnum.ENROLLED,
                DateFrom = DateTime.Now,
                Student = studentDto,
                Subject = subjectDto
            };

            var result = await _studentStateSvc.CreateAsync(newState);
            return !result.HasError;
        }

        public override Task<bool> StoreAttendenceAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> TakeAnExamAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            throw new NotImplementedException();
        }
    }
}
