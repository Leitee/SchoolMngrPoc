using Pandora.NetStdLibrary.Base.Interfaces;
using Pandora.NetStdLibrary.Base.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface IStudentSvc : IBasicCrudOperations<StudentDto>
    {
        Task<BLListResponse<StudentDto>> GetStudentsAttendsBySubjectId(int pSubjectId);
        Task<BLSingleResponse<bool>> SaveStudentExams(StudentDto pStudent);
        Task<BLListResponse<StudentDto>> GetStudentsExamsBySubjectId(int pSubjectId);
    }
}
