using Task.BLL.Helper;
using Task.Repository;
using Task.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task.BLL
{
    public class StepManager
    {
        IUnitOfWork _uow;
        public StepManager(IUnitOfWork UOW)
        {
            _uow = UOW;
        }

        public async Task<ResponseDTO> GetSteps()
        {
            ResponseDTO response = new ResponseDTO();
            try
            {                

                var _Steps = await _uow.Step.GetAll("Items");
                _Steps.Where(x => x.IsDeleted == false);
                response.Data = _Steps;
                response.IsSuccess = true;
                response.Message = "Steps retrieved successfully";
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message.ToString();
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Data = null;
            }
            return response;
        }

        public async Task<ResponseDTO> GetStepByKey(Int64 Id)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {

                var _Step = await _uow.Step.GetEntity(Id,"Items");

                response.Data = _Step;
                response.IsSuccess = true;
                response.Message = "Steps retrieved successfully";
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message.ToString();
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Data = null;
            }
            return response;
        }
        public async Task<ResponseDTO> AddStep(Step step)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {

               await _uow.Step.Add(step);
               await _uow.Commite();

                response.Data = null;
                response.IsSuccess = true;
                response.Message = "Steps Added successfully";
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message.ToString();
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Data = null;
            }
            return response;
        }

        public async Task<ResponseDTO> UpdateStep(Step step)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {

                _uow.Step.Update(step);
                await _uow.Commite();

                response.Data = null;
                response.IsSuccess = true;
                response.Message = "Steps Updated successfully";
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message.ToString();
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Data = null;
            }
            return response;
        }

        public async Task<ResponseDTO> SoftDeleteStep(Int64 stepId)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                var _stepEntity = _uow.Context.Set<Step>().Find(stepId);
                _stepEntity.IsDeleted = true;

                _uow.Step.Update(_stepEntity);
                await _uow.Commite();
               

                response.Data = null;
                response.IsSuccess = true;
                response.Message = "Steps Deleted successfully";
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message.ToString();
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Data = null;
            }
            return response;
        }
    }
}
