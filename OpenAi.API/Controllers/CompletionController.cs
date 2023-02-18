using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using OpenAI.Helpers.Articles.Response;
using OpenAI.Helpers.Services.OpenAICompletion;
using System.Runtime.CompilerServices;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;

namespace OpenAi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletionController : ControllerBase
    {
        private readonly IOpenAICompletionServices _openAiCompletionServices;
        private readonly IOpenAIImageServices _openAiImageServices;
        public CompletionController(IOpenAICompletionServices openAiCompletionServices, IOpenAIImageServices openAiImageServices)
        {
            _openAiCompletionServices = openAiCompletionServices;
            _openAiImageServices = openAiImageServices;
        }

        [HttpPost("CreateChatCompletion")]
        public async Task<IActionResult> ChatCompletion(string promptData)
        {
            GetOneResult<CompletionCreateResponse> completionResponse = new();
            try
            {
                completionResponse = await _openAiCompletionServices.CreateChatCompletion(promptData);
                return Ok(completionResponse);
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message + " " + ex.InnerException?.Message;
                completionResponse.IsSuccess = false;
                completionResponse.Entity = null;
                completionResponse.Message = exceptionMessage;
                return BadRequest(completionResponse);
            }
        }
        
        [HttpPost("CreateImageCompletion")]
        public async Task<IActionResult> ImageCompletion(string promptData)
        {
            GetOneResult<ImageCreateResponse> imageCompletionResponse = new();
            try
            {
                imageCompletionResponse = await _openAiImageServices.CreateImageCompletion(promptData);
                return Ok(imageCompletionResponse);
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message + " " + ex.InnerException?.Message;
                imageCompletionResponse.IsSuccess = false;
                imageCompletionResponse.Entity = null;
                imageCompletionResponse.Message = exceptionMessage;
                return BadRequest(imageCompletionResponse);
            }
        }
    }
}