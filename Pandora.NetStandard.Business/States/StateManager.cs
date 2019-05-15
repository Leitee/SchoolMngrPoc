using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Enums;
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

        public async static Task<StateManager> GetStateManagerAsync(IStudentStateSvc studentStateSvc, StudentDto studentDto, SubjectDto subjectDto)
        {
            var validState = studentDto.StudentState ?? (await studentStateSvc.GetLastValidStateAsync(studentDto, subjectDto)).Data;

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

        public abstract Task<bool> EnrollAsync(StudentDto studentDto, SubjectDto subjectDto);
        public abstract Task<bool> TakeAnExamAsync(StudentDto studentDto, SubjectDto subjectDto);
        public abstract Task<bool> StoreAttendenceAsync(StudentDto studentDto, SubjectDto subjectDto);
    }
}
