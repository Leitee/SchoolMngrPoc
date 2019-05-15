using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Model.Dtos;

namespace Pandora.NetStandard.Business.States
{
    public class StudentEnrolledState : StateManager
    {
        public StudentEnrolledState(IStudentStateSvc studentStateSvc) : base(studentStateSvc)
        {
        }

        public override Task<bool> EnrollAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> StoreAttendenceAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            throw new NotImplementedException();
        }

        public async override Task<bool> TakeAnExamAsync(StudentDto studentDto, SubjectDto subjectDto)
        {
            throw new NotImplementedException();    
        }
    }
}
