using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Business.States;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class SubjectSvc : BaseService<Subject, SubjectDto>, ISubjectSvc
    {
        private readonly IStudentStateSvc _studentStateSvc;
        public SubjectSvc(IApplicationUow applicationUow, ILogger<SubjectSvc> logger,
            IStudentStateSvc studentStateSvc)
            : base(applicationUow, logger, new SubjectToDtoMapper())
        {
            _studentStateSvc = studentStateSvc;
        }

        public async Task<BLSingleResponse<SubjectDto>> CreateAsync(SubjectDto pDto)
        {
            var response = new BLSingleResponse<SubjectDto>();

            try
            {
                var entityResult = await _uow.GetRepo<Subject>().InsertAsync(pDto);
                if (await _uow.CommitAsync())
                {
                    response.Data = _mapper.MapEntity(entityResult);
                }
                else
                {
                    HandleSVCException(response, "This action couldn't be performed.");
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> DeleteAsync(SubjectDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLListResponse<SubjectDto>> GetAllAsync()
        {
            var response = new BLListResponse<SubjectDto>();

            try
            {
                var entitiesResult = await _uow.GetRepo<Subject>().AllAsync(null, null, null);
                response.Data = _mapper.MapEntity(entitiesResult);
                
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> SaveSubjectExams(SubjectDto pSubject)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                await _uow.GetRepo<Subject>().UpdateAsync(pSubject);
                if (await _uow.CommitAsync())
                {
                    response.Data = true;
                }
                else
                {
                    HandleSVCException(response, "This action couldn't be performed.");
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<SubjectDto>> GetByIdAsync(int pId)
        {
            var response = new BLSingleResponse<SubjectDto>();

            try
            {
                var entityResult = await _uow.GetRepo<Subject>().GetByIdAsync(pId);
                response.Data = _mapper.MapEntity(entityResult);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> UpdateAsync(SubjectDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLSingleResponse<bool>> EnrollStudentAsync(StudentDto studentDto, int subjectId)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                var subjResponse = await GetByIdAsync(subjectId);
                if (subjResponse.HasError || subjResponse.Data == null)
                    throw new Exception($"Subject Id = {subjectId} didn't match any result.");

                StateManager stateManager = await StateManager.GetStateManagerAsync(_studentStateSvc, studentDto.Id, subjectId);
                response.Data = await stateManager.EnrollStudentAsync(studentDto, subjResponse.Data);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> SaveExamResultAsync(IList<ExamDto> examDtos)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                foreach (ExamDto exam in examDtos)
                {
                    await _uow.GetRepo<Exam>().InsertAsync(exam);
                }

                if(await _uow.CommitAsync())
                {
                    StateManager stateManager = await StateManager.GetStateManagerAsync(_studentStateSvc, examDtos.FirstOrDefault().StudentId, examDtos.FirstOrDefault().SubjectId);
                    response.Data = await stateManager.SaveExamsResultAsync(examDtos);
                }
                else
                {
                    response.Data = false;
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLListResponse<SubjectDto>> GetByTeacherIdAsync(int teacherId)
        {
            var response = new BLListResponse<SubjectDto>();

            try
            {
                var entitiesResult = await _uow.GetRepo<Subject>().AllAsync(sb => sb.SubjectAssingments.Any(sa => sa.TeacherId.Value == teacherId),
                    null,
                    x => x.Include(sb => sb.SubjectAssingments).ThenInclude(sa => sa.Class), x => x.Include(sb => sb.Attends));

                response.Data = _mapper.MapEntity(entitiesResult);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        
    }
}
