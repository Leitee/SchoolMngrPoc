using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface ISubjectSvc : IBasicCrudOperations<SubjectDto>
    {
        Task<BLSingleResponse<bool>> TryEnrollAsync(int subjectId, int studentId);
        Task<BLSingleResponse<bool>> EnrollStudentAsync(int subjectId, int userId);
        Task<BLSingleResponse<bool>> SaveAttendsAsync(int subjectId, IList<StudentDto> studentDtos);
        Task<BLSingleResponse<bool>> SaveExamResultAsync(int subjectId, StudentDto studentDto);
        Task<BLListResponse<SubjectDto>> GetByUserIdAsync<TEntity>(int userId) where TEntity : class;
    }
}