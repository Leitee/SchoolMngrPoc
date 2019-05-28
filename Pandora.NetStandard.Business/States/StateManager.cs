using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Util;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.States
{
    public abstract class StateManager
    {
        protected static IStudentStateSvc _studentStateSvc;

        public StateManager(IStudentStateSvc studentStateSvc)
        {
            _studentStateSvc = studentStateSvc;
        }

        public async static Task<StateManager> GetStateManagerAsync(IStudentStateSvc studentStateSvc, int studentId, int subjectId)
        {
            var validState = (await studentStateSvc.GetLastValidStateAsync(studentId, subjectId)).Data;

            switch (validState?.AcademicState)
            {
                case StudentStateEnum.ENROLLED:
                    return new StudentEnrolledState(studentStateSvc);
                case StudentStateEnum.ACTIVE:
                    return null;
                case StudentStateEnum.INACTIVE:
                    return null;
                case StudentStateEnum.ACHIEVED:
                    return null;
                default:
                    return new StudentInitialState(studentStateSvc);
            }
        }

        public abstract Task<bool> EnrollStudentAsync(StudentDto studentDto, SubjectDto subjectDto);
        public abstract Task<bool> SaveExamsResultAsync(IList<ExamDto> examDtos);
        public abstract Task<bool> StoreAttendenceAsync(StudentDto studentDto, SubjectDto subjectDto);

        protected virtual bool StateManagerResponseHandler(BLResponse bLResponse)
        {
            if(bLResponse == null)
                throw new StateManagerException("Null Result Exception");
            else if (bLResponse.HasError)
                throw new StateManagerException(string.Concat(bLResponse.Errors.ToArray()));
            else
                return true;
        }
    }
}
