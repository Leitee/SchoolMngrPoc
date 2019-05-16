using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface IStudentSvc : IBasicCrudOperations<StudentDto>
    {
        Task<BLListResponse<StudentDto>> GetAllExamsResultsByClass(int pClassId);
        Task<BLSingleResponse<bool>> SaveStudentExams(StudentDto pStudent);
        Task<BLListResponse<StudentDto>> GetStudentsByClassId(int pClassId);
    }
}
