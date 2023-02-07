using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using OpenAI.Helpers.Articles.Response;
using OpenAI.Helpers.Services.OpenAICompletion;
using System.Runtime.CompilerServices;

namespace OpenAi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletionController : ControllerBase
    {
        public IOpenAICompletionServices _openAiCompletionServices;
        public CompletionController(IOpenAICompletionServices openAiCompletionServices)
        {
            _openAiCompletionServices = openAiCompletionServices;
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
    }
}