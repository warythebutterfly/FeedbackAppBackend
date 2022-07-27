using FeedbackAppBackend.Formatting;
using FeedbackAppBackend.IServices;
using FeedbackAppBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [Route("getall")]
        [HttpGet]
        public async Task<DataResult> GetFeedback()
        {
            var responses = ApiResponse.GetApiResponseMessages();
            DataResult dataResult;
            try
            {
                if (!ModelState.IsValid)
                {
                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.BadRequest],
                        Message = ApiResponse.ApiResponseStatus.BadRequest.ToString(),
                        Data = false
                    };
                }

                try
                {
                    object data = await _feedbackService.GetFeedbacks();
                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.Successful],
                        Message = ApiResponse.ApiResponseStatus.Successful.ToString(),
                        Data = data
                    };
                }
                catch (CustomException ex)
                {

                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.Failed],
                        Message = ex.Message,
                        Data = false
                    };
                }
            }

            catch (Exception ex)
            {

                dataResult = new DataResult
                {
                    StatusCode = responses[ApiResponse.ApiResponseStatus.UnknownError],
                    Message = ApiResponse.ApiResponseStatus.UnknownError.ToString(),
                    ExceptionErrorMessage = ex.Message,
                    Data = null
                };
            }
            return dataResult;
        }

        [Route("create")]
        [HttpPost]
        public async Task<DataResult> CreateFeedback([FromBody] FeedbackViewModel model)
        {
            var responses = ApiResponse.GetApiResponseMessages();
            DataResult dataResult;
            try
            {
                if (!ModelState.IsValid)
                {
                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.BadRequest],
                        Message = ApiResponse.ApiResponseStatus.BadRequest.ToString(),
                        Data = false
                    };
                }

                try
                {
                    object data = await _feedbackService.CreateFeedback(model);
                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.Successful],
                        Message = ApiResponse.ApiResponseStatus.Successful.ToString(),
                        Data = data
                    };
                }
                catch (CustomException ex)
                {

                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.Failed],
                        Message = ex.Message,
                        Data = false
                    };
                }
            }

            catch (Exception ex)
            {

                dataResult = new DataResult
                {
                    StatusCode = responses[ApiResponse.ApiResponseStatus.UnknownError],
                    Message = ApiResponse.ApiResponseStatus.UnknownError.ToString(),
                    ExceptionErrorMessage = ex.Message,
                    Data = null
                };
            }
            return dataResult;
        }

        [Route("update")]
        [HttpPut]
        public async Task<DataResult> EditFeedback([FromBody] FeedbackViewModel model)
        {
            var responses = ApiResponse.GetApiResponseMessages();
            DataResult dataResult;
            try
            {
                if (!ModelState.IsValid)
                {
                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.BadRequest],
                        Message = ApiResponse.ApiResponseStatus.BadRequest.ToString(),
                        Data = false
                    };
                }

                try
                {
                    object data = await _feedbackService.UpdateFeedback(model);
                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.Successful],
                        Message = ApiResponse.ApiResponseStatus.Successful.ToString(),
                        Data = data
                    };
                }
                catch (CustomException ex)
                {

                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.Failed],
                        Message = ex.Message,
                        Data = false
                    };
                }
            }

            catch (Exception ex)
            {

                dataResult = new DataResult
                {
                    StatusCode = responses[ApiResponse.ApiResponseStatus.UnknownError],
                    Message = ApiResponse.ApiResponseStatus.UnknownError.ToString(),
                    ExceptionErrorMessage = ex.Message,
                    Data = null
                };
            }
            return dataResult;
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<DataResult> DeleteFeedback(int id)
        {
            var responses = ApiResponse.GetApiResponseMessages();
            DataResult dataResult;
            try
            {
                if (!ModelState.IsValid)
                {
                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.BadRequest],
                        Message = ApiResponse.ApiResponseStatus.BadRequest.ToString(),
                        Data = false
                    };
                }

                try
                {
                    object data = await _feedbackService.DeleteFeedback(id);
                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.Successful],
                        Message = ApiResponse.ApiResponseStatus.Successful.ToString(),
                        Data = data
                    };
                }
                catch (CustomException ex)
                {

                    dataResult = new DataResult
                    {
                        StatusCode = responses[ApiResponse.ApiResponseStatus.Failed],
                        Message = ex.Message,
                        Data = false
                    };
                }
            }

            catch (Exception ex)
            {

                dataResult = new DataResult
                {
                    StatusCode = responses[ApiResponse.ApiResponseStatus.UnknownError],
                    Message = ApiResponse.ApiResponseStatus.UnknownError.ToString(),
                    ExceptionErrorMessage = ex.Message,
                    Data = null
                };
            }
            return dataResult;
        }
    }
}
